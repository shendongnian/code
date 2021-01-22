    public static class MyLogManager
    {
        // for illustration, you should configure this somewhere else...
        private static string configFile = @"path\to\log4net.config";
        public static void GetLogger(Type type)
        {
            if(log4net.LogManager.GetCurrentLoggers().Length == 0)
            {
                // load logger config with XmlConfigurator
                log4net.Config.XmlConfigurator.Configure(configFile);
            }
            return LogManager.GetLogger(type);
        }
    }
