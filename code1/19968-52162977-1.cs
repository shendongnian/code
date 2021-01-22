    public class LogWrapper
        {
            public ILog Setup(string logFilePath, string logName, string maxFileSize = "10MB")
            {
                var patternLayout = new PatternLayout();
                patternLayout.ConversionPattern = "%date [%thread] %-5level %logger - %message%newline";
                patternLayout.ActivateOptions();
                var roller = new RollingFileAppender();
                roller.AppendToFile = true;
                roller.File = logFilePath;
                roller.Layout = patternLayout;
                roller.MaxSizeRollBackups = 5;
                roller.MaximumFileSize = maxFileSize;
                roller.RollingStyle = RollingFileAppender.RollingMode.Size;
                roller.StaticLogFileName = true;
                roller.ActivateOptions();
                //hierarchy.Root.AddAppender(roller);
                var memory = new MemoryAppender();
                memory.ActivateOptions();
                ILog log = LogManager.GetLogger(logName);
                var l = (Logger)log.Logger;
                l.AddAppender(roller);
                l.AddAppender(memory);
                l.Level = l.Hierarchy.LevelMap["Debug"];
                l.Repository.Configured = true;
                return log;
            }
        }
