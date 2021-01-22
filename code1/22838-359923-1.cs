		/// <summary>
		/// Retrieves an RSA public key from a signed assembly
		/// </summary>
		/// <param name="assembly">Signed assembly to retrieve the key from</param>
		/// <returns>RSA Crypto Service Provider initialised with the key from the assembly</returns>
		public static RSACryptoServiceProvider GetPublicKeyFromAssembly(Assembly assembly)
		{
			if (assembly == null)
				throw new ArgumentNullException("assembly", "Assembly may not be null");
			byte[] pubkey = assembly.GetName().GetPublicKey();
			if (pubkey.Length == 0)
				throw new ArgumentException("No public key in assembly.");
			RSAParameters rsaParams = EncryptionUtils.GetRSAParameters(pubkey);
			RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
			rsa.ImportParameters(rsaParams);
			return rsa;
		}
