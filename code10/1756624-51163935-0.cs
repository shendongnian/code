    string path = null;
    if(!File.Exists(destUrl))
    {
    	path = destUrl;
    }
    else
    {
    	if(!File.Exists(destUrl2))
    	{
    		path = destUrl2;
    	}
    }
    
    if(!string.IsNullOrWhiteSpace(path))
    {
    	try
    	{
    		SPFile destFile = projectid.RootFolder.Files.Add(path, fileBytes, false);
    	}
    	catch
    	{
    		// Something prevented file from being written -> handle this as your workflow dictates
    	}
    }
