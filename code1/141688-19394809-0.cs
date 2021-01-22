    private static ILog _log = LogManager.GetLogger(typeof(Program));
    public static ILog Log
    {
        get
        {
            if(!log4net.LogManager.GetRepository().Configured)
            log4net.Config.XmlConfigurator.Configure(new FileInfo(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile));
            return _log;
        }
    }
