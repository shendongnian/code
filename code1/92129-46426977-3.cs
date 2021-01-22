    public string Version()
    {
        Version version = null;
    
        if (ApplicationDeployment.IsNetworkDeployed)
    	{
    	    version = ApplicationDeployment.CurrentDeployment.CurrentVersion;
    	}
    	else
    	{
    	    version = typeof(ThisAddIn).Assembly.GetName().Version;
    	}
    
    	return version.ToString();
    }
