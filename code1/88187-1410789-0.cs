    public void Initialize(String LogFileName)
        {
            log4net.Appender.RollingFileAppender appender = new log4net.Appender.RollingFileAppender();
            appender.Layout = new log4net.Layout.PatternLayout("%d - %m%n");
            appender.File = LogFileName;
            appender.MaxSizeRollBackups = 10;
            appender.MaximumFileSize = "100MB";
            appender.AppendToFile = true;
            appender.Threshold = log4net.Core.Level.Debug;
            appender.ActivateOptions();
            log4net.Config.BasicConfigurator.Configure(appender);
            _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName);
            _logger.Debug("Application started");
        }
