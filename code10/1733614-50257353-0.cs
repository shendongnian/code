    public class Logger
    {
        private const string Warn = "Warn";
        private const string Info = "Info";
    
        public LogInfo(string message)
        {
            Log(Info, message);
        }
    
        public LogWarn(string message)
        {
             Log(Warn, message);
        }
    
        private Log(string trigger, string message)
        {
            // do something
        }
    }
