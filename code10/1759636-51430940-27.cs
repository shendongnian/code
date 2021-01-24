    private static log4net.ILog log;
    static void Main(String args)
    {
        String appIdentifier = args[0];
    
        if (!log4net.LogManager.GetRepository().Configured)
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo("C:\\Program Files\\Symplexity\\bin\\Log4NetSettingsGlobal.xml"));
            
            log = log4net.LogManager.GetLogger(appIdentifier); 
        }
        // ...
    }
