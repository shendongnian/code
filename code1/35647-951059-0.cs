    // Set logfile name and application name variables
    log4net.GlobalContext.Properties["LogName"] = GetType().Assembly.GetName().Name + ".log";
    log4net.GlobalContext.Properties["ApplicationName"] = GetType().Assembly.GetName().Name;
    // Load log4net configuration
    System.IO.FileInfo logfile = new System.IO.FileInfo(Server.MapPath("log4net.config"));
    log4net.Config.XmlConfigurator.ConfigureAndWatch(logfile);
    //Get the loger
    _pLog = log4net.LogManager.GetLogger("Global.asax");
    // Record application startup
    pLog .Debug("Application startup");
