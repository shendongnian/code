    public class Log4NetWrapper : ILogger {
        private readonly ILog log; //log4net 
        public Log4NetWrapper(ILog log) {
            this.log = log;
        }
        public void LogMessage(string msg) {
            log.Info(msg);
        }
        //...
    }
    
