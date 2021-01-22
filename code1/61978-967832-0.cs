    int Rfc2898KeygenIterations = 100;
    int AesKeySizeInBits = 128;
    String Password = "VerySecret!";
    byte[] Salt = new byte[16];
    System.Random rnd = new System.Random();
    rnd.NextBytes(Salt);
    
    byte[] rawPlaintext = System.Text.Encoding.Unicode.GetBytes("This is all clear now!");
    
    byte[] cipherText = null;
    byte[] plainText = null;
    
    using (Aes aes = new AesManaged())
    {
    	aes.Padding = PaddingMode.PKCS7;
    	aes.KeySize = AesKeySizeInBits;
    	int KeyStrengthInBytes = aes.KeySize / 8;
    	System.Security.Cryptography.Rfc2898DeriveBytes rfc2898 =
    		new System.Security.Cryptography.Rfc2898DeriveBytes(Password, Salt, Rfc2898KeygenIterations);
    	aes.Key = rfc2898.GetBytes(KeyStrengthInBytes);
    	aes.IV = rfc2898.GetBytes(KeyStrengthInBytes);
    
    	using (MemoryStream ms = new MemoryStream())
    	{
    		using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
    		{
    			cs.Write(rawPlaintext, 0, rawPlaintext.Length);
    		}
    
    		cipherText = ms.ToArray();
    	}
    
    
    	using (MemoryStream ms = new MemoryStream())
    	{
    		using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
    		{
    			cs.Write(cipherText, 0, cipherText.Length);
    		}
    
    		plainText = ms.ToArray();
    	}
    }
