    using System;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure.KeyVault;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    
    namespace AzureKeyVaultTestApp1
    {
        static class Program
        {
            static HashAlgorithmName _hashAlg = HashAlgorithmName.SHA1;
            static string _clientId = "00000000-0000-0000-0000-000000000000";
            static string _clientSecret = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            static string _certId = "https://XXXXXXXX.vault.azure.net/certificates/TestCert1/XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            static string _keyId = "https://XXXXXXXX.vault.azure.net/keys/TestCert1/XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
    
            static async Task<string> AuthenticationCallback(string authority, string resource, string scope)
            {
                var context = new AuthenticationContext(authority);
                var result = await context.AcquireTokenAsync(resource, new ClientCredential(_clientId, _clientSecret));
                return result.AccessToken;
            }
    
            static async Task Main(string[] args)
            {
                KeyVaultClient client = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(AuthenticationCallback));
    
                // Compute digest of data
                byte[] dataToSign = Encoding.ASCII.GetBytes("Hello world!");
                byte[] hash = HashAlgorithm.Create(_hashAlg.Name).ComputeHash(dataToSign);
    
                // Construct DER encoded PKCS#1 DigestInfo structure defined in RFC 8017
                byte[] pkcs1DigestInfo = CreatePkcs1DigestInfo(hash, _hashAlg);
    
                // Sign digest with private key
                var keyOperationResult = await client.SignAsync(_keyId, "RSNULL", pkcs1DigestInfo).ConfigureAwait(false);
                byte[] signature = keyOperationResult.Result;
    
                // Get public key from certificate
                var certBundle = await client.GetCertificateAsync(_certId).ConfigureAwait(false);
                X509Certificate2 cert = new X509Certificate2(certBundle.Cer);
                RSA rsaPubKey = cert.GetRSAPublicKey();
    
                // Verify digest signature with public key
                if (!rsaPubKey.VerifyHash(hash, signature, _hashAlg, RSASignaturePadding.Pkcs1))
                    throw new Exception("Invalid signature");
            }
    
            private static byte[] CreatePkcs1DigestInfo(byte[] hash, HashAlgorithmName hashAlgorithm)
            {
                if (hash == null || hash.Length == 0)
                    throw new ArgumentNullException(nameof(hash));
    
                byte[] pkcs1DigestInfo = null;
    
                if (hashAlgorithm == HashAlgorithmName.MD5)
                {
                    if (hash.Length != 16)
                        throw new ArgumentException("Invalid lenght of hash value");
    
                    pkcs1DigestInfo = new byte[] { 0x30, 0x20, 0x30, 0x0C, 0x06, 0x08, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x02, 0x05, 0x05, 0x00, 0x04, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                    Array.Copy(hash, 0, pkcs1DigestInfo, pkcs1DigestInfo.Length - hash.Length, hash.Length);
                }
                else if (hashAlgorithm == HashAlgorithmName.SHA1)
                {
                    if (hash.Length != 20)
                        throw new ArgumentException("Invalid lenght of hash value");
    
                    pkcs1DigestInfo = new byte[] { 0x30, 0x21, 0x30, 0x09, 0x06, 0x05, 0x2B, 0x0E, 0x03, 0x02, 0x1A, 0x05, 0x00, 0x04, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                    Array.Copy(hash, 0, pkcs1DigestInfo, pkcs1DigestInfo.Length - hash.Length, hash.Length);
                }
                else if (hashAlgorithm == HashAlgorithmName.SHA256)
                {
                    if (hash.Length != 32)
                        throw new ArgumentException("Invalid lenght of hash value");
    
                    pkcs1DigestInfo = new byte[] { 0x30, 0x31, 0x30, 0x0D, 0x06, 0x09, 0x60, 0x86, 0x48, 0x01, 0x65, 0x03, 0x04, 0x02, 0x01, 0x05, 0x00, 0x04, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                    Array.Copy(hash, 0, pkcs1DigestInfo, pkcs1DigestInfo.Length - hash.Length, hash.Length);
                }
                else if (hashAlgorithm == HashAlgorithmName.SHA384)
                {
                    if (hash.Length != 48)
                        throw new ArgumentException("Invalid lenght of hash value");
    
                    pkcs1DigestInfo = new byte[] { 0x30, 0x41, 0x30, 0x0D, 0x06, 0x09, 0x60, 0x86, 0x48, 0x01, 0x65, 0x03, 0x04, 0x02, 0x02, 0x05, 0x00, 0x04, 0x30, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                    Array.Copy(hash, 0, pkcs1DigestInfo, pkcs1DigestInfo.Length - hash.Length, hash.Length);
                }
                else if (hashAlgorithm == HashAlgorithmName.SHA512)
                {
                    if (hash.Length != 64)
                        throw new ArgumentException("Invalid lenght of hash value");
    
                    pkcs1DigestInfo = new byte[] { 0x30, 0x51, 0x30, 0x0D, 0x06, 0x09, 0x60, 0x86, 0x48, 0x01, 0x65, 0x03, 0x04, 0x02, 0x03, 0x05, 0x00, 0x04, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                    Array.Copy(hash, 0, pkcs1DigestInfo, pkcs1DigestInfo.Length - hash.Length, hash.Length);
                }
    
                return pkcs1DigestInfo;
            }
        }
    }
