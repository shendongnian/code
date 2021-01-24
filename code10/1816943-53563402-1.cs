    using System;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    
    using Windows.Storage.Streams;
    using Windows.Security.Cryptography;
    using Windows.Security.Cryptography.Core;
    using Windows.Security.Cryptography.Certificates;
    
    using Org.BouncyCastle.Cms;
    using Org.BouncyCastle.X509;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.OpenSsl;
    using Org.BouncyCastle.Asn1.X509;
    using Org.BouncyCastle.Asn1.Smime;
    using Org.BouncyCastle.X509.Store;
    using Org.BouncyCastle.Crypto.Parameters;
    
    using MimeKit.IO;
    
    namespace MimeKit.Cryptography
    {
    	public class UWPSecureMimeContext : SecureMimeContext
    	{
    		readonly CertificateStore userStore;
    
    		public UWPSecureMimeContext (CertificateStore userStore)
    		{
    			this.userStore = userStore;
    
    			// UWP does not support Camellia...
    			Disable (EncryptionAlgorithm.Camellia256);
    			Disable (EncryptionAlgorithm.Camellia192);
    			Disable (EncryptionAlgorithm.Camellia192);
    
    			// ... or Blowfish/Twofish...
    			Disable (EncryptionAlgorithm.Blowfish);
    			Disable (EncryptionAlgorithm.Twofish);
    
    			// ...or CAST5...
    			Disable (EncryptionAlgorithm.Cast5);
    
    			// ...or IDEA...
    			Disable (EncryptionAlgorithm.Idea);
    
    			// ...or SEED...
    			Disable (EncryptionAlgorithm.Seed);
    		}
    
    		public UWPSecureMimeContext (string userStore) : this (CertificateStores.GetStoreByName (userStore))
    		{
    		}
    
    		public UWPSecureMimeContext () : this (CertificateStores.GetStoreByName ("MimeKit"))
    		{
    		}
    
    		/// <summary>
    		/// Check whether or not the cryptography context can encrypt to a particular recipient.
    		/// </summary>
    		/// <remarks>
    		/// Checks whether or not the cryptography context can be used to encrypt to a particular recipient.
    		/// </remarks>
    		/// <returns><c>true</c> if the cryptography context can be used to encrypt to the designated recipient; otherwise, <c>false</c>.</returns>
    		/// <param name="mailbox">The recipient's mailbox address.</param>
    		/// <exception cref="System.ArgumentNullException">
    		/// <paramref name="mailbox"/> is <c>null</c>.
    		/// </exception>
    		public override bool CanEncrypt (MailboxAddress mailbox)
    		{
    			if (mailbox == null)
    				throw new ArgumentNullException (nameof (mailbox));
    
    			return GetRecipientCertificate (mailbox) != null;
    		}
    
    		/// <summary>
    		/// Check whether or not a particular mailbox address can be used for signing.
    		/// </summary>
    		/// <remarks>
    		/// Checks whether or not as particular mailbocx address can be used for signing.
    		/// </remarks>
    		/// <returns><c>true</c> if the mailbox address can be used for signing; otherwise, <c>false</c>.</returns>
    		/// <param name="signer">The signer.</param>
    		/// <exception cref="System.ArgumentNullException">
    		/// <paramref name="signer"/> is <c>null</c>.
    		/// </exception>
    		public override bool CanSign (MailboxAddress signer)
    		{
    			if (signer == null)
    				throw new ArgumentNullException (nameof (signer));
    
    			return GetSignerCertificate (signer) != null;
    		}
    
    		static byte ToXDigit (char c)
    		{
    			if (c >= 0x41) {
    				if (c >= 0x61)
    					return (byte) (c - (0x61 - 0x0a));
    
    				return (byte) (c - (0x41 - 0x0A));
    			}
    
    			return (byte) (c - 0x30);
    		}
    
    		static byte[] HexDecode (string value)
    		{
    			var decoded = new byte[value.Length / 2];
    
    			for (int i = 0; i < decoded.Length; i++) {
    				var b1 = ToXDigit (value[i * 2]);
    				var b2 = ToXDigit (value[i * 2 + 1]);
    
    				decoded[i] = (byte) ((b1 << 4) | b2);
    			}
    
    			return decoded;
    		}
    
    		async Task<Certificate> GetCertificate (MailboxAddress mailbox, bool sign)
    		{
    			var secure = mailbox as SecureMailboxAddress;
    			var query = new CertificateQuery ();
    			var now = DateTimeOffset.UtcNow;
    
    			if (secure != null)
    				query.Thumbprint = HexDecode (secure.Fingerprint);
    			else
    				query.FriendlyName = mailbox.Address;
    
    			// TODO: filter on key usages
    
    			foreach (var certificate in await CertificateStores.FindAllAsync (query)) {
    				if (certificate.ValidFrom > now || certificate.ValidTo < now)
    					continue;
    
    				return certificate;
    			}
    
    			return null;
    		}
    
    		/// <summary>
    		/// Get the certificate for the specified recipient.
    		/// </summary>
    		/// <remarks>
    		/// <para>Gets the certificate for the specified recipient.</para>
    		/// <para>If the mailbox is a <see cref="SecureMailboxAddress"/>, the
    		/// <see cref="SecureMailboxAddress.Fingerprint"/> property will be used instead of
    		/// the mailbox address.</para>
    		/// </remarks>
    		/// <returns>The certificate to use for the recipient; otherwise, or <c>null</c>.</returns>
    		/// <param name="mailbox">The recipient's mailbox address.</param>
    		protected virtual Certificate GetRecipientCertificate (MailboxAddress mailbox)
    		{
    			return GetCertificate (mailbox, false).GetAwaiter ().GetResult ();
    		}
    
    		/// <summary>
    		/// Get the certificate for the specified signer.
    		/// </summary>
    		/// <remarks>
    		/// <para>Gets the certificate for the specified signer.</para>
    		/// <para>If the mailbox is a <see cref="SecureMailboxAddress"/>, the
    		/// <see cref="SecureMailboxAddress.Fingerprint"/> property will be used instead of
    		/// the mailbox address.</para>
    		/// </remarks>
    		/// <returns>The certificate to use for the signer; otherwise, or <c>null</c>.</returns>
    		/// <param name="mailbox">The signer's mailbox address.</param>
    		protected virtual Certificate GetSignerCertificate (MailboxAddress mailbox)
    		{
    			return GetCertificate (mailbox, true).GetAwaiter ().GetResult ();
    		}
    
    		static byte[] ReadAllBytes (Stream stream)
    		{
    			if (stream is MemoryBlockStream)
    				return ((MemoryBlockStream) stream).ToArray ();
    
    			if (stream is MemoryStream)
    				return ((MemoryStream) stream).ToArray ();
    
    			using (var memory = new MemoryBlockStream ()) {
    				stream.CopyTo (memory, 4096);
    				return memory.ToArray ();
    			}
    		}
    
    		static async Task<byte[]> ReadAllBytesAsync (Stream stream, CancellationToken cancellationToken)
    		{
    			if (stream is MemoryBlockStream)
    				return ((MemoryBlockStream) stream).ToArray ();
    
    			if (stream is MemoryStream)
    				return ((MemoryStream) stream).ToArray ();
    
    			using (var memory = new MemoryBlockStream ()) {
    				await stream.CopyToAsync (memory, 4096, cancellationToken).ConfigureAwait (false);
    				return memory.ToArray ();
    			}
    		}
    
    		static AsymmetricKeyParameter LoadPrivateKey (IBuffer buffer)
    		{
    			AsymmetricKeyParameter key = null;
    			byte[] keyData;
    
    			CryptographicBuffer.CopyToByteArray (buffer, out keyData);
    
    			using (var memory = new MemoryStream (keyData, false)) {
    				using (var reader = new StreamReader (memory)) {
    					var pem = new PemReader (reader);
    
    					var keyObject = pem.ReadObject ();
    
    					if (keyObject != null) {
    						key = keyObject as AsymmetricKeyParameter;
    
    						if (key == null) {
    							var pair = keyObject as AsymmetricCipherKeyPair;
    
    							if (pair != null)
    								key = pair.Private;
    						}
    					}
    				}
    			}
    
    			if (key == null || !key.IsPrivate)
    				return null;
    
    			return key;
    		}
    
    		/// <summary>
    		/// Gets the private key for the certificate matching the specified selector.
    		/// </summary>
    		/// <remarks>
    		/// Gets the private key for the first certificate that matches the specified selector.
    		/// </remarks>
    		/// <returns>The private key on success; otherwise <c>null</c>.</returns>
    		/// <param name="selector">The search criteria for the private key.</param>
    		protected virtual async Task<AsymmetricKeyParameter> GetPrivateKeyAsync (IX509Selector selector)
    		{
    			// first we need to find the certificate...
    			var match = selector as X509CertStoreSelector;
    			var query = new CertificateQuery ();
    
    			if (match == null)
    				return null;
    			
    			if (match.Certificate != null)
    				query.Thumbprint = HexDecode (match.Certificate.GetFingerprint ());
    
    			if (match.Issuer != null)
    				query.IssuerName = match.Issuer.ToString ();
    
    			var certificates = await CertificateStores.FindAllAsync (query);
    			var certificate = certificates.FirstOrDefault ();
    
    			if (certificate == null)
    				return null;
    
    			// now get the key
    
    			// TODO: what hash algo/padding do we want? does it matter?
    			var key = await PersistedKeyProvider.OpenKeyPairFromCertificateAsync (certificate, HashAlgorithmNames.Sha256, CryptographicPadding.RsaPkcs1V15);
    			var buffer = key.Export (CryptographicPrivateKeyBlobType.Pkcs1RsaPrivateKey);
    
    			return LoadPrivateKey (buffer);
    		}
    
    		/// <summary>
    		/// Gets the private key for the certificate matching the specified selector.
    		/// </summary>
    		/// <remarks>
    		/// Gets the private key for the first certificate that matches the specified selector.
    		/// </remarks>
    		/// <returns>The private key on success; otherwise <c>null</c>.</returns>
    		/// <param name="selector">The search criteria for the private key.</param>
    		protected virtual AsymmetricKeyParameter GetPrivateKey (IX509Selector selector)
    		{
    			return GetPrivateKeyAsync (selector).GetAwaiter ().GetResult ();
    		}
    
    		/// <summary>
    		/// Decrypt the specified encryptedData.
    		/// </summary>
    		/// <remarks>
    		/// Decrypts the specified encryptedData.
    		/// </remarks>
    		/// <returns>The decrypted <see cref="MimeKit.MimeEntity"/>.</returns>
    		/// <param name="encryptedData">The encrypted data.</param>
    		/// <param name="cancellationToken">The cancellation token.</param>
    		/// <exception cref="System.ArgumentNullException">
    		/// <paramref name="encryptedData"/> is <c>null</c>.
    		/// </exception>
    		/// <exception cref="Org.BouncyCastle.Cms.CmsException">
    		/// An error occurred in the cryptographic message syntax subsystem.
    		/// </exception>
    		/// <exception cref="System.OperationCanceledException">
    		/// The operation was cancelled via the cancellation token.
    		/// </exception>
    		public override MimeEntity Decrypt (Stream encryptedData, CancellationToken cancellationToken = default (CancellationToken))
    		{
    			if (encryptedData == null)
    				throw new ArgumentNullException (nameof (encryptedData));
    
    			var parser = new CmsEnvelopedDataParser (encryptedData);
    			var recipients = parser.GetRecipientInfos ();
    			var algorithm = parser.EncryptionAlgorithmID;
    			AsymmetricKeyParameter key;
    
    			foreach (RecipientInformation recipient in recipients.GetRecipients ()) {
    				if ((key = GetPrivateKey (recipient.RecipientID)) == null)
    					continue;
    
    				var content = recipient.GetContent (key);
    				var memory = new MemoryStream (content, false);
    
    				return MimeEntity.Load (memory, true, cancellationToken);
    			}
    
    			throw new CmsException ("A suitable private key could not be found for decrypting.");
    		}
    		/// <summary>
    		/// Decrypt the specified encryptedData to an output stream.
    		/// </summary>
    		/// <remarks>
    		/// Decrypts the specified encryptedData to an output stream.
    		/// </remarks>
    		/// <param name="encryptedData">The encrypted data.</param>
    		/// <param name="decryptedData">The output stream.</param>
    		/// <exception cref="System.ArgumentNullException">
    		/// <para><paramref name="encryptedData"/> is <c>null</c>.</para>
    		/// <para>-or-</para>
    		/// <para><paramref name="decryptedData"/> is <c>null</c>.</para>
    		/// </exception>
    		/// <exception cref="Org.BouncyCastle.Cms.CmsException">
    		/// An error occurred in the cryptographic message syntax subsystem.
    		/// </exception>
    		public override void DecryptTo (Stream encryptedData, Stream decryptedData)
    		{
    			if (encryptedData == null)
    				throw new ArgumentNullException (nameof (encryptedData));
    
    			if (decryptedData == null)
    				throw new ArgumentNullException (nameof (decryptedData));
    
    			var parser = new CmsEnvelopedDataParser (encryptedData);
    			var recipients = parser.GetRecipientInfos ();
    			var algorithm = parser.EncryptionAlgorithmID;
    			AsymmetricKeyParameter key;
    
    			foreach (RecipientInformation recipient in recipients.GetRecipients ()) {
    				if ((key = GetPrivateKey (recipient.RecipientID)) == null)
    					continue;
    
    				var content = recipient.GetContentStream (key);
    
    				content.ContentStream.CopyTo (decryptedData, 4096);
    				return;
    			}
    
    			throw new CmsException ("A suitable private key could not be found for decrypting.");
    		}
    
    		static string GetHashAlgorithmName (DigestAlgorithm digestAlgo)
    		{
    			switch (digestAlgo) {
    			case DigestAlgorithm.MD5: return HashAlgorithmNames.Md5;
    			case DigestAlgorithm.Sha1: return HashAlgorithmNames.Sha1;
    			case DigestAlgorithm.Sha256: return HashAlgorithmNames.Sha256;
    			case DigestAlgorithm.Sha384: return HashAlgorithmNames.Sha384;
    			case DigestAlgorithm.Sha512: return HashAlgorithmNames.Sha512;
    			default: throw new NotSupportedException ($"The {digestAlgo} digest algorithm is not supported on the Universal Windows Platform.");
    			}
    		}
    
    		static Certificate GetCertificate (X509Certificate x509)
    		{
    			var buffer = CryptographicBuffer.CreateFromByteArray (x509.GetEncoded ());
    
    			return new Certificate (buffer);
    		}
    
    		Stream Sign (Certificate certificate, IList<Certificate> chain, DigestAlgorithm digestAlgo, Stream content, bool detach)
    		{
    			var signerInfo = new CmsSignerInfo ();
    			var signers = new CmsSignerInfo[1];
    			byte[] signedData;
    			IBuffer buffer;
    
    			signerInfo.HashAlgorithmName = GetHashAlgorithmName (digestAlgo);
    			signerInfo.Certificate = certificate;
    			signers[0] = signerInfo;
    
    			if (detach) {
    				using (var input = content.AsInputStream ())
    					buffer = CmsDetachedSignature.GenerateSignatureAsync (input, signers, chain).GetResults ();
    			} else {
    				buffer = CryptographicBuffer.CreateFromByteArray (ReadAllBytes (content));
    				buffer = CmsAttachedSignature.GenerateSignatureAsync (buffer, signers, chain).GetResults ();
    			}
    			
    			CryptographicBuffer.CopyToByteArray (buffer, out signedData);
    
    			return new MemoryStream (signedData, false);
    		}
    
    		/// <summary>
    		/// Cryptographically signs and encapsulates the content using the specified signer.
    		/// </summary>
    		/// <remarks>
    		/// Cryptographically signs and encapsulates the content using the specified signer.
    		/// </remarks>
    		/// <returns>A new <see cref="MimeKit.Cryptography.ApplicationPkcs7Mime"/> instance
    		/// containing the detached signature data.</returns>
    		/// <param name="signer">The signer.</param>
    		/// <param name="content">The content.</param>
    		/// <exception cref="System.ArgumentNullException">
    		/// <para><paramref name="signer"/> is <c>null</c>.</para>
    		/// <para>-or-</para>
    		/// <para><paramref name="content"/> is <c>null</c>.</para>
    		/// </exception>
    		/// <exception cref="System.Security.Cryptography.CryptographicException">
    		/// An error occurred in the cryptographic message syntax subsystem.
    		/// </exception>
    		public override ApplicationPkcs7Mime EncapsulatedSign (CmsSigner signer, Stream content)
    		{
    			if (signer == null)
    				throw new ArgumentNullException (nameof (signer));
    
    			if (content == null)
    				throw new ArgumentNullException (nameof (content));
    
    			var certificate = GetCertificate (signer.Certificate);
    			IList<Certificate> chain = null;
    
    			// FIXME: does the chain need to include the signer's cert as well?
    			if (signer.CertificateChain.Count > 1) {
    				chain = new List<Certificate> (signer.CertificateChain.Count - 1);
    
    				for (int i = 1; i < signer.CertificateChain.Count; i++)
    					chain.Add (GetCertificate (signer.CertificateChain[i]));
    			}
    
    			return new ApplicationPkcs7Mime (SecureMimeType.SignedData, Sign (certificate, chain, signer.DigestAlgorithm, content, false));
    		}
    
    		/// <summary>
    		/// Sign and encapsulate the content using the specified signer.
    		/// </summary>
    		/// <remarks>
    		/// Sign and encapsulate the content using the specified signer.
    		/// </remarks>
    		/// <returns>A new <see cref="MimeKit.Cryptography.ApplicationPkcs7Mime"/> instance
    		/// containing the detached signature data.</returns>
    		/// <param name="signer">The signer.</param>
    		/// <param name="digestAlgo">The digest algorithm to use for signing.</param>
    		/// <param name="content">The content.</param>
    		/// <exception cref="System.ArgumentNullException">
    		/// <para><paramref name="signer"/> is <c>null</c>.</para>
    		/// <para>-or-</para>
    		/// <para><paramref name="content"/> is <c>null</c>.</para>
    		/// </exception>
    		/// <exception cref="System.ArgumentOutOfRangeException">
    		/// <paramref name="digestAlgo"/> is out of range.
    		/// </exception>
    		/// <exception cref="System.NotSupportedException">
    		/// The specified <see cref="DigestAlgorithm"/> is not supported by this context.
    		/// </exception>
    		/// <exception cref="CertificateNotFoundException">
    		/// A signing certificate could not be found for <paramref name="signer"/>.
    		/// </exception>
    		/// <exception cref="System.Security.Cryptography.CryptographicException">
    		/// An error occurred in the cryptographic message syntax subsystem.
    		/// </exception>
    		public override ApplicationPkcs7Mime EncapsulatedSign (MailboxAddress signer, DigestAlgorithm digestAlgo, Stream content)
    		{
    			if (signer == null)
    				throw new ArgumentNullException (nameof (signer));
    
    			if (content == null)
    				throw new ArgumentNullException (nameof (content));
    
    			var certificate = GetSignerCertificate (signer);
    
    			return new ApplicationPkcs7Mime (SecureMimeType.SignedData, Sign (certificate, null, digestAlgo, content, false));
    		}
    
    		public override ApplicationPkcs7Mime Encrypt (CmsRecipientCollection recipients, Stream content)
    		{
    			throw new NotImplementedException ();
    		}
    
    		public override MimePart Encrypt (IEnumerable<MailboxAddress> recipients, Stream content)
    		{
    			throw new NotImplementedException ();
    		}
    
    		public override MimePart Export (IEnumerable<MailboxAddress> mailboxes)
    		{
    			throw new NotImplementedException ();
    		}
    
    		public override void Import (Stream stream, string password)
    		{
    			throw new NotImplementedException ();
    		}
    
    		public override void Import (X509Certificate certificate)
    		{
    			throw new NotImplementedException ();
    		}
    
    		public override void Import (X509Crl crl)
    		{
    			throw new NotImplementedException ();
    		}
    
    		/// <summary>
    		/// Cryptographically signs the content using the specified signer.
    		/// </summary>
    		/// <remarks>
    		/// Cryptographically signs the content using the specified signer.
    		/// </remarks>
    		/// <returns>A new <see cref="MimeKit.Cryptography.ApplicationPkcs7Signature"/> instance
    		/// containing the detached signature data.</returns>
    		/// <param name="signer">The signer.</param>
    		/// <param name="content">The content.</param>
    		/// <exception cref="System.ArgumentNullException">
    		/// <para><paramref name="signer"/> is <c>null</c>.</para>
    		/// <para>-or-</para>
    		/// <para><paramref name="content"/> is <c>null</c>.</para>
    		/// </exception>
    		/// <exception cref="System.Security.Cryptography.CryptographicException">
    		/// An error occurred in the cryptographic message syntax subsystem.
    		/// </exception>
    		public override ApplicationPkcs7Signature Sign (CmsSigner signer, Stream content)
    		{
    			if (signer == null)
    				throw new ArgumentNullException (nameof (signer));
    
    			if (content == null)
    				throw new ArgumentNullException (nameof (content));
    
    			var certificate = GetCertificate (signer.Certificate);
    			IList<Certificate> chain = null;
    
    			// FIXME: does the chain need to include the signer's cert as well?
    			if (signer.CertificateChain.Count > 1) {
    				chain = new List<Certificate> (signer.CertificateChain.Count - 1);
    
    				for (int i = 1; i < signer.CertificateChain.Count; i++)
    					chain.Add (GetCertificate (signer.CertificateChain[i]));
    			}
    
    			return new ApplicationPkcs7Signature (Sign (certificate, chain, signer.DigestAlgorithm, content, true));
    		}
    
    		/// <summary>
    		/// Sign the content using the specified signer.
    		/// </summary>
    		/// <remarks>
    		/// Sign the content using the specified signer.
    		/// </remarks>
    		/// <returns>A new <see cref="MimeKit.MimePart"/> instance
    		/// containing the detached signature data.</returns>
    		/// <param name="signer">The signer.</param>
    		/// <param name="digestAlgo">The digest algorithm to use for signing.</param>
    		/// <param name="content">The content.</param>
    		/// <exception cref="System.ArgumentNullException">
    		/// <para><paramref name="signer"/> is <c>null</c>.</para>
    		/// <para>-or-</para>
    		/// <para><paramref name="content"/> is <c>null</c>.</para>
    		/// </exception>
    		/// <exception cref="System.ArgumentOutOfRangeException">
    		/// <paramref name="digestAlgo"/> is out of range.
    		/// </exception>
    		/// <exception cref="System.NotSupportedException">
    		/// The specified <see cref="DigestAlgorithm"/> is not supported by this context.
    		/// </exception>
    		/// <exception cref="CertificateNotFoundException">
    		/// A signing certificate could not be found for <paramref name="signer"/>.
    		/// </exception>
    		/// <exception cref="System.Security.Cryptography.CryptographicException">
    		/// An error occurred in the cryptographic message syntax subsystem.
    		/// </exception>
    		public override MimePart Sign (MailboxAddress signer, DigestAlgorithm digestAlgo, Stream content)
    		{
    			if (signer == null)
    				throw new ArgumentNullException (nameof (signer));
    
    			if (content == null)
    				throw new ArgumentNullException (nameof (content));
    
    			var certificate = GetSignerCertificate (signer);
    
    			return new ApplicationPkcs7Signature (Sign (certificate, null, digestAlgo, content, true));
    		}
    
    		public override DigitalSignatureCollection Verify (Stream signedData, out MimeEntity entity, CancellationToken cancellationToken = default (CancellationToken))
    		{
    			throw new NotImplementedException ();
    		}
    
    		public override Stream Verify (Stream signedData, out DigitalSignatureCollection signatures, CancellationToken cancellationToken = default (CancellationToken))
    		{
    			throw new NotImplementedException ();
    		}
    
    		public override DigitalSignatureCollection Verify (Stream content, Stream signatureData, CancellationToken cancellationToken = default (CancellationToken))
    		{
    			throw new NotImplementedException ();
    		}
    
    		public override Task<DigitalSignatureCollection> VerifyAsync (Stream content, Stream signatureData, CancellationToken cancellationToken = default (CancellationToken))
    		{
    			throw new NotImplementedException ();
    		}
    	}
    }
