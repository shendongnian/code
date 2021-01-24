    public class CustomLogger
    {
        private readonly ILog _log;
        public CustomLogger()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var configFileDirectory = Path.Combine(baseDirectory, "log4net.config");
            FileInfo configFileInfo = new FileInfo(configFileDirectory);
            log4net.Config.XmlConfigurator.ConfigureAndWatch(configFileInfo);
            _log = log4net.LogManager.GetLogger("log4netFileLogger");
        }
        public void Info(string value)
        {
            _log.Info(value);
        }
    }
