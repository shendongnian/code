    using (var reader1 = new System.IO.FileStream(filepath1, System.IO.FileMode.Open, System.IO.FileAccess.Read))
    {
    	using (var reader2 = new System.IO.FileStream(filepath2, System.IO.FileMode.Open, System.IO.FileAccess.Read))
    	{
    		byte[] hash1;
    		byte[] hash2;
    
    		using (var md51 = new System.Security.Cryptography.MD5CryptoServiceProvider())
    		{
    			md51.ComputeHash(reader1);
    			hash1 = md51.Hash;
    		}
    
    		using (var md52 = new System.Security.Cryptography.MD5CryptoServiceProvider())
    		{
    			md52.ComputeHash(reader2);
    			hash2 = md52.Hash;
    		}
    
    		int j = 0;
    		for (j = 0; j < hash1.Length; j++)
    		{
    			if (hash1[j] != hash2[j])
    			{
    				break;
    			}
    		}
    
    		if (j == hash1.Length)
    		{
    			Console.WriteLine("The files were equal.");
    		}
    		else
    		{
    			Console.WriteLine("The files were not equal.");
    		}
    	}
    }
