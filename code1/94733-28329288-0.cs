    private static void SetLogPath(string path, string errorPath)
    {
        XmlConfigurator.Configure();
        log4net.Repository.Hierarchy.Hierarchy h =
        (log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository();
        foreach (var a in h.Root.Appenders)
        {
            if (a is log4net.Appender.FileAppender)
            {
                if (a.Name.Equals("LogFileAppender"))
                { 
                    log4net.Appender.FileAppender fa = (log4net.Appender.FileAppender)a;                    
                    string logFileLocation = path; 
                    fa.File = logFileLocation;                   
                    fa.ActivateOptions();
                }
                else if (a.Name.Equals("ErrorFileAppender"))
                {
                    log4net.Appender.FileAppender fa = (log4net.Appender.FileAppender)a;
                    string logFileLocation = errorPath;
                    fa.File = logFileLocation;
                    fa.ActivateOptions();
                }
            }
        }
    }
      
