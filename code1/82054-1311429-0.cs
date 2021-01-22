     class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            var file = Path.Combine(Directory.GetCurrentDirectory(), Guid.NewGuid() + ".log");
            var log = InitialiseLogToFile(file);
            log.Info("Made it here!");
            log.Error("Made it here!");
            var file2 = Path.Combine(Directory.GetCurrentDirectory(), Guid.NewGuid() + ".log");
            var log2 = InitialiseLogToFile(file2);
            log2.Info("Made it here!");
            log2.Error("Made it here!");
        }
        public static ILog InitialiseLogToFile(string file)
        {
            LogManager.ResetConfiguration();
            var hierarchy = (Hierarchy)LogManager.GetLoggerRepository();
            var patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%d [%t] %-5p %c [%x] - %m%n";
            patternLayout.ActivateOptions();
            
            var appender = new FileAppender {File = file, AppendToFile = true, Layout = patternLayout};
            appender.ActivateOptions();
            var logger = (Logger)hierarchy.GetLogger(file);
            logger.AddAppender(appender);
            hierarchy.Configured = true;
            return LogManager.GetLogger(file);
        }
    }
