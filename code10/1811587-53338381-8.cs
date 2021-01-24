    public class Log4NetWrapper : ILogger {
        private readonly ILog log; //log4net 
    
        public LogWrapper(ILog log) {
            this.log = log;
        }
    
        public void LogMessage(string msg) {
            log.Info(msg);
        }
        //...
    }
