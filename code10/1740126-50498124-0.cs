    public static class Logger
    {
        private static string _unclassified = "Unclassified";
        [Obsolete("Please supply a LoggerName and LoggerLevel")]
        public static void Log(string message)
        {          
            Log(_unclassified,LogLevel.Info, message,null);
        }
        [Obsolete("Please supply a LoggerName")]
        public static void Log(LogLevel level, string message)
        {
            Log(_unclassified,level,message,null);
        }
        [Obsolete("Please supply a LoggerName and LoggerLevel")]
        public static void Log(Exception ex)
        {          
            Log(_unclassified,LogLevel.Info, "",ex);
        }
        public static void Log(LoggerNames name, LogLevel level , string message)
        {
            
            NLog.LogLevel nLevel = NLog.LogLevel.FromString(level.ToString());
            Log(name.ToString(), level, message);
        }
        public static void Log(LoggerNames name, LogLevel level, Exception ex, string message)
        {
            
            NLog.LogLevel nLevel = NLog.LogLevel.FromString(level.ToString());
            Log(name.ToString(),level,message,ex);
        }
        private static void Log(string loggerName, LogLevel level, string message, Exception ex = null)
        {
            if (level == LogLevel.Warning)
                level = LogLevel.Warn;
            NLog.LogLevel nLevel = NLog.LogLevel.FromString(level.ToString());
            LogEventInfo logEvent = new LogEventInfo(nLevel,loggerName,null,message,null,ex);
            NLog.LogManager.GetLogger(loggerName).Log(typeof(Logger), logEvent);
        }
    }
