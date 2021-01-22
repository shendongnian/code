    public void SaveConfig(Configuration config)
    {
    	RemotingManager.ShutdownTargetApplication();
    	config.NamespaceDeclared = true;
    
    	// check if session expired
    	if (String.IsNullOrEmpty(ApplicationPath) ||
    		String.IsNullOrEmpty((string)Session[APP_PHYSICAL_PATH]))
    	{
    		Server.Transfer("~/home2.aspx");
    	}
    
    	config.Save(ConfigurationSaveMode.Minimal);
    }
