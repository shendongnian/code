    // again, thinly veiled wrapper to log4net. so long as we are able to
    // implement these methods, however, we do not care who the actual
    // provider is
    public static class LogProvider
    {
        public static ILog GetLogger<T>()
        {
            return GetLoggerByType(typeof(T));
        }
        public static ILog GetLoggerByName(string name)
        {
            global::log4net.ILog log4netLogger = 
                global::log4net.LogManager.GetLogger(name);
            // Log4NetLog is an implementation of our ILog
            // that accepts a lognet:ILog and delegates to it
            ILog logger = new Log4NetLog(log4netLogger);
            return logger;
        }
        public static ILog GetLoggerByType(Type type)
        {
            global::log4net.ILog log4netLogger = 
                global::log4net.LogManager.GetLogger(type);
            ILog logger = new Log4NetLog(log4netLogger);
            return logger;
        }
    }
