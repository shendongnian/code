    private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Global.asax");
    void Application_Start(object sender, EventArgs e) 
    {
        // Set logfile name and application name variables
        log4net.GlobalContext.Properties["LogName"] = GetType().Assembly.GetName().Name + ".log";
        log4net.GlobalContext.Properties["ApplicationName"] = GetType().Assembly.GetName().Name;
    
        // Load log4net configuration
        System.IO.FileInfo logfile = new System.IO.FileInfo(Server.MapPath("log4net.config"));
        log4net.Config.XmlConfigurator.ConfigureAndWatch(logfile);
    
        // Record application startup
        log.Debug("Application startup");
    }
