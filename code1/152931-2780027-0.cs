    public static string DecryptTextFromMemory(byte[] Data, byte[] Key, byte[] IV)
    {
    	try
    	{
    		// Create a new MemoryStream using the passed
    		// array of encrypted data.
    		MemoryStream msDecrypt = new MemoryStream();
    
    		// Create a CryptoStream using the MemoryStream
    		// and the passed key and initialization vector (IV).
    		CryptoStream csDecrypt = new CryptoStream(msDecrypt,
    		new TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV),
    		CryptoStreamMode.Write);
    
    		csDecrypt.Write(Data, 0, Data.Length);
    		csDecrypt.FlushFinalBlock();
    		msDecrypt.Position = 0;
    
    		// Create buffer to hold the decrypted data.
    		byte[] fromEncrypt = new byte[msDecrypt.Length];
    
    		// Read the decrypted data out of the crypto stream
    		// and place it into the temporary buffer.
    		msDecrypt.Read(fromEncrypt, 0, msDecrypt.ToArray().Length);
    		csDecrypt.Close();
    
    		//Convert the buffer into a string and return it.
    		return new UTF8Encoding().GetString(fromEncrypt);
    	}
    	catch (CryptographicException e)
    	{
    		MessageBox.Show("A Cryptographic error occurred: {0}", e.Message);
    		return null;
    	}
    }
