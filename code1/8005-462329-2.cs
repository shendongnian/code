    //1. Provide early notification that the user does not have permission to write.
    FileIOPermission writePermission = new FileIOPermission(FileIOPermissionAccess.Write, filename);
    if(!SecurityManager.IsGranted(writePermission))
    {
    	//No permission. 
    	//Either throw an exception so this can be handled by a calling function
    	//or inform the user that they do not have permission to write to the folder and return.
    }
    
    //2. Attempt the action but handle permission changes.
    try
    {
    	using (FileStream fstream = new FileStream(filename, FileMode.Create))
    	using (TextWriter writer = new StreamWriter(fstream))
    	{
    		writer.WriteLine("sometext");
    	}
    }
    catch (UnauthorizedAccessException ex)
    {
    	//No permission. 
    	//Either throw an exception so this can be handled by a calling function
    	//or inform the user that they do not have permission to write to the folder and return.
    }
