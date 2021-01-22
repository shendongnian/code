    public static class MyLogManager
    {
        public static void GetLogger(Type type)
        {
            if(log4net.LogManager.GetCurrentLoggers().Count() > 0)
            {
                // load logger config with XmlConfigurator
                log4net.Config.XmlConfigurator.Configure(configFile);
            }
            return LogManager.GetLogger(type);
        }
    }
