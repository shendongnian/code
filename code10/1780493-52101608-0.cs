    try
        {
    		if (System.IO.File.Exists(path))
    		{
    			System.IO.File.SetAttributes(path, FileAttributes.Normal);
    			System.IO.File.Delete(path);
    		}
    	}
        catch (Exception e)
            {
    			// Handle error
            }
