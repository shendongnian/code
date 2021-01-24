    foreach (String entry in contents)
    {
    	if (System.IO.File.Exists(entry))
    	{
    		try {
    #if (DEBUG)
    			FileInfo fi = new FileInfo(entry);
    			if (fi.LastAccessTime < DateTime.Now.AddMinutes(-3))
    			{
    #endif
    				System.IO.File.Delete(entry);
    #if (DEBUG)
    			}
    #endif
    		}
    		catch (Exception e)
    		{
    			//ignore
    		}
    	}
    }
