    public static bool IsLegalFilename(string name)
    {
    	try 
    	{
    		var fileInfo = new FileInfo(name);
    		return true;
    	}
    	catch
    	{
    		return false;
    	}
    }
