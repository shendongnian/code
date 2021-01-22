    public static void AddAppenderToLogger(string loggerName, string fileName) {
        FileAppender appender = new FileAppender();
        appender.Name = string.Format("appender_{0}", loggerName);
        appender.File = fileName;
        appender.AppendToFile = true;
        appender.Layout = new PatternLayout("%date - %message%newline");
        appender.LockingModel = new log4net.Appender.FileAppender.MinimalLock();
        appender.ActivateOptions();
        ILoggerRepository repository = LogManager.CreateRepository(string.Format("repository_{0}",loggerName));
        log4net.Config.BasicConfigurator.Configure(repository, appender);
    }
    public static ILog GetLogger(string loggerName){
        return LogManager.GetLogger(string.Format("repository_{0}", loggerName), loggerName);
    }
    //Using in application code:
        static void Main(string[] args) {
            AddAppenderToLogger("test", @"c:\testLog.txt");
            ILog log = GetLogger("test");
            log.Info("TestRecord");           
        }
          
