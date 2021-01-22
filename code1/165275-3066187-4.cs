    public static class Context
    {
        private static BaseLogger LogObject;
    
        static Context() {}
    
        public static BaseLogger Log
        {
            get { return LogObject ?? LogFactory.instance; }
            set { LogObject = value; }
        }
    
        private class LogFactory
        {
            static LogFactory() {}
            internal static readonly BaseLogger instance 
                   = new BaseLogger(null, null, null);
        }
    }
