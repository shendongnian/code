    public class ExtendLogger : Microsoft.Build.Logging.ConsoleLogger
    {
        private string savedLog;
        public ExtendLogger(): base()
        {
            base.WriteHandler = this.SaveLog;
        }
        void SaveLog(string message)
        {
            savedLog += message;
        }
        public string GetLog()
        {
            return savedLog;
        }
    }
