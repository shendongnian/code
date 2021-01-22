    public static string Encrypt(string plainText)
	{
		byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
		byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
		var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
		var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
		
		byte[] cipherTextBytes;
		using (var memoryStream = new MemoryStream())
		{
			using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
			{
				cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
				cryptoStream.FlushFinalBlock();
				cipherTextBytes = memoryStream.ToArray();
				cryptoStream.Close();
			}
			memoryStream.Close();
		}
		return Convert.ToBase64String(cipherTextBytes);
	}
