    public static void protectWithPassword(string input, string output)
    {
    	using (PdfDocument doc = new PdfDocument(input))
    	{
    		// set owner password (a password required to change permissions)
    		doc.OwnerPassword = "pass";
    
    		// set empty user password (this will allow anyone to
    		// view document without need to enter password)
    		doc.UserPassword = "";
    
    		// setup encryption algorithm
    		doc.Encryption = PdfEncryptionAlgorithm.Aes128Bit;
    
    		// [optionally] setup permissions
    		doc.Permissions.CopyContents = false;
    		doc.Permissions.ExtractContents = false;
    
    		doc.Save(output);
    	}
    }
