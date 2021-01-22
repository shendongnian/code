    public class Log4netTraceListener : System.Diagnostics.TraceListener
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger("System.Diagnostics.Redirection");
        public Log4netTraceListener(log4net.ILog logger)
        {
            Log4netTraceListener.logger = logger;
        }
        public override void Write(string message)
        {
            logger.Debug(message);
        }
        public override void WriteLine(string message)
        {
            logger.Debug(message);
        }
    }
