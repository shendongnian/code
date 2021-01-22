    public void ExportToFile(string filename)
    {
    	FileIOPermission writePermission = new FileIOPermission(FileIOPermissionAccess.Write, filename);
    
    	if (SecurityManager.IsGranted(writePermission))
    	{
    		using (FileStream fstream = new FileStream(filename, FileMode.Create))
    		using (TextWriter writer = new StreamWriter(fstream))
    		{
    			// try catch block for write permissions 
    			writer.WriteLine("sometext");
    
    
    		}
    	}
    	else
    	{
    		//perform some recovery action here
    	}
    	
    }
