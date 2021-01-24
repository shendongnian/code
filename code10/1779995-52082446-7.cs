    public class Log
    {
        private ILog _log;
        public Log()
        {
            FileInfo configFileInfo = new FileInfo("log4net.config");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(configFileInfo);
            _log = log4net.LogManager.GetLogger("log4netFileLogger");
        }
        public void write(string value)
        {
            _log.Info(value);
        }
    }
