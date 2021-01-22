    string[] args = Environment.GetCommandLineArgs();
    // The first (0 index) commandline argument is the exe path.
    if (args.Length > 1)
    {
        if (Array.IndexOf(args, "/live") != -1)
        {
            // connection string = 
    		// ConfigurationSettings.AppSettings["LiveConString"];
        }
    }
    else
    {
    	// connection string = 
    	// ConfigurationSettings.AppSettings["TestConString"];
    }
