	static byte[] Sign(string text, string certSubject)
	{
		// Access a store
		using (X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser))
		{
			store.Open(OpenFlags.ReadOnly);
			// Find the certificate used to sign
			RSACryptoServiceProvider provider = null;
			foreach (X509Certificate2 cert in store.Certificates)
			{
				if (cert.Subject.Contains(certSubject))
				{
					// Get its associated CSP and private key
					provider = (RSACryptoServiceProvider)cert.PrivateKey;
					break;
				}
			}
			if (provider == null)
				throw new Exception("Certificate not found.");
			// Hash the data
			var hash = HashText(text);
			// Sign the hash
			var signature = provider.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
			return signature;
		}                
	}
	static bool Verify(string text, byte[] signature, string certPath)
	{
		// Load the certificate used to verify the signature
		X509Certificate2 certificate = new X509Certificate2(certPath);
					
		// Get its associated provider and public key
		RSACryptoServiceProvider provider = (RSACryptoServiceProvider)certificate.PublicKey.Key;
		// Hash the data
		var hash = HashText(text);
		
		// Verify the signature with the hash
		var result = provider.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), signature);
		return result;
	}
	static byte[] HashText(string text)
	{
		SHA1Managed sha1Hasher = new SHA1Managed();
		UnicodeEncoding encoding = new UnicodeEncoding();
		byte[] data = encoding.GetBytes(text);
		byte[] hash = sha1Hasher.ComputeHash(data);
		return hash;
	}
