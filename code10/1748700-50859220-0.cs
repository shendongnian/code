    private static void Run()
    {
    	try
    	{
    		// Get unencrypted data from Settings.dat
    		string[] unencrypted = File.ReadAllLines("C:\\Program Files (x86)\\theAPPSettings\\Settings.dat");
    
    		string unencryptedGuid = unencrypted[0]; //its only 1 setting that I'm interested in
    
    		// Create a file.
    		FileStream fStream = new FileStream("C:\\Program Files (x86)\\theAPPSettings\\ProtectedSettings.dat", FileMode.OpenOrCreate);
    
    		byte[] toEncrypt = UnicodeEncoding.ASCII.GetBytes(unencryptedGuid);                
    		
    		byte[] entropy = UnicodeEncoding.ASCII.GetBytes("A Shared Phrase between the encryption and decryption");
    
    		// Encrypt a copy of the data to the stream.
    		int bytesWritten = Protection.EncryptDataToStream(toEncrypt, entropy, DataProtectionScope.CurrentUser, fStream);
    
    		fStream.Close();
    
    		File.Delete("C:\\Program Files (x86)\\theAPPSettings\\Settings.dat");
    
    		//Console.ReadKey();
    	}
    	catch (Exception e)
    	{
    		Console.WriteLine("ERROR: " + e.Message);
    	}
    }
