    public static string Decrypt(string encryptedText)
	{
		byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
		byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
		var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };
		var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
		var memoryStream = new MemoryStream(cipherTextBytes);
		var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
		byte[] plainTextBytes = new byte[cipherTextBytes.Length];
		int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
		memoryStream.Close();
		cryptoStream.Close();
		return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
	}
