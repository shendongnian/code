    public void ExportToFile(string filename)
    {
    	var writePermission = new FileIOPermission(FileIOPermissionAccess.Write, filename);
        var permissionSet = new PermissionSet(PermissionState.None);    
        permissionSet.AddPermission(permission);
    	if (permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet))
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
