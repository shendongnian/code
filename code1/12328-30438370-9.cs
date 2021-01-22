    public static string Encrypt(string clearText)
	{            
		byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
		using (Aes encryptor = Aes.Create())
		{
			byte[] IV = new byte[15];
			rand.NextBytes(IV);
			Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, IV);
			encryptor.Key = pdb.GetBytes(32);
			encryptor.IV = pdb.GetBytes(16);
			using (MemoryStream ms = new MemoryStream())
			{
				using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
				{
					cs.Write(clearBytes, 0, clearBytes.Length);
					cs.Close();
				}
				clearText = Convert.ToBase64String(IV) + Convert.ToBase64String(ms.ToArray());
			}
		}
		return clearText;
	}
