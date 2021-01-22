        private static ILog GetLog(string logName)
        {
            ILog log = LogManager.GetLogger(logName);
            log4net.Config.XmlConfigurator.Configure();
            return log;
        }
