    public class Log4NetExtensionMethods {
        // simple string wrapper
        public void Log_Debug(this log4net.ILog logger, string logMessage) {
            if(logger.isDebugEnabled) {
                 logger.Debug(logMessage);
            }
        }
        // this takes a delegate so you can delay execution
        // of a function call until you've determined it's necessary
        public void Log_Debug(this log4net.ILog logger, Func<string> logMessageDelegate) {
            if(logger.isDebugEnabled) {
                 logger.Debug(logMessageDelegate());
            }
        }
    }
