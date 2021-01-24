    public static class CryptoHelper
    {
    	//Init the key and Vector
    	public static void InitDESKeys()
    	{
    	    try
    	    {
    		MemoryStream tempStream = new MemoryStream();
    		string[] charkey = Resources.CryptoKeys.DesKey.Split(',');
    		string[] chariv = Resources.CryptoKeys.DesVector.Split(',');
    		MemoryStream MemoryStreamkey = new MemoryStream(DesKey);
    		MemoryStream MemoryStreamiv = new MemoryStream(DesVector);
    
    		foreach (string item in charkey)
    		{
    		    MemoryStreamkey.WriteByte(Convert.ToByte(item, 16));
    		}
    
    		foreach (string item in chariv)
    		{
    		    MemoryStreamiv.WriteByte(Convert.ToByte(item, 16));
    		}
    	    }
    	    catch (Exception ex)
    	    {
    
    	    }
    	}
    
    	//Create function DESEncrypt to manage the encryption
    
    	public static string DESEncrypt(string sourceData)
    	{
    	    try
    	    {
    		byte[] sourceDataBytes = System.Text.Encoding.Unicode.GetBytes(sourceData);
    		MemoryStream tempStream = new MemoryStream();
    		DESCryptoServiceProvider encryptor = new DESCryptoServiceProvider();
    		CryptoStream encryptionStream = new CryptoStream(tempStream, encryptor.CreateEncryptor(DesKey, DesVector), CryptoStreamMode.Write);
    		encryptionStream.Write(sourceDataBytes, 0, sourceDataBytes.Length);
    		encryptionStream.FlushFinalBlock();
    		byte[] encryptedDataBytes = tempStream.GetBuffer();
    		return Convert.ToBase64String(encryptedDataBytes, 0, (int)tempStream.Length);
    	    }
    	    catch (Exception ex)
    	    {
    		throw new Exception("Unable to encrypt data.");
    	    }
    	}
    
    	//Create function DESDecrypt to manage the decryption
    
    	public static string DESDecrypt(string sourceData)
    	{
    	    try
    	    {
    		byte[] encryptedDataBytes = Convert.FromBase64String(sourceData);
    		MemoryStream tempStream = new MemoryStream(encryptedDataBytes, 0, encryptedDataBytes.Length);
    		DESCryptoServiceProvider decryptor = new DESCryptoServiceProvider();
    		CryptoStream decryptionStream = new CryptoStream(tempStream, decryptor.CreateDecryptor(DesKey, DesVector), CryptoStreamMode.Read);
    		//StreamReader allDataReader = new StreamReader(decryptionStream);
    		//return allDataReader.ReadToEnd();
    		byte[] bytesCryptedData = new byte[tempStream.Length];
    		decryptionStream.Read(bytesCryptedData, 0, (int)tempStream.Length);
    
    		var CryptedDataText = System.Text.Encoding.Unicode.GetString(bytesCryptedData);
    		return CryptedDataText;
    	    }
    	    catch (Exception ex)
    	    {
    		throw new Exception("Unable to encrypt data.");
    	    }
    	}
    }
