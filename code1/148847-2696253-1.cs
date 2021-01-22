	if (!System.IO.File.Exists(ConfigurationManager.ConfigFile))
    {
		// Display config file locator dialog
        ConfigurationManager.ConfigFile = someDialog.FileName;
    }
    try
    {
		IConfig config = ConfigurationManager.Config;
    }
    catch
    {
		// Error parsing config file
    }
