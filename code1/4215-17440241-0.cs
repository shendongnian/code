    public static string AppPath
    {
    	get
    	{
    		var appPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
    
    		while(appPath.FullName.Contains(@"\bin\", StringComparison.CurrentCultureIgnoreCase))
    		{
    			appPath = appPath.Parent;
    		}
    		return appPath.FullName;
    	}
    }
    public static string BinPath
    {
    	get
    	{
    		string binPath = AppDomain.CurrentDomain.BaseDirectory;
    
    		if (!binPath.Contains(@"\bin\", StringComparison.CurrentCultureIgnoreCase))
    		{
    			binPath = Path.Combine(binPath, "bin");
    //-- Please improve this is there is a better way
    #if DEBUG
    			binPath = Path.Combine(binPath, "Debug");
    #else
    			binPath = Path.Combine(binPath, "Release");
    #endif
    		}
    			return binPath;
    	}
    }
