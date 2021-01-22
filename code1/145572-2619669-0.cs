    public class Log4NetExtensionMethods {
    
        public void Log_Debug(this log4net.ILog logger, string logMessage) {
            if(logger.isDebugEnabled) {
                 logger.Debug(logMessage);
            }
        }
    }
