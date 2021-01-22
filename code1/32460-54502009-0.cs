    public class Log4netTraceListener : System.Diagnostics.TraceListener
    {
        private readonly log4net.ILog _log;
        public Log4netTraceListener()
            : this(log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType))
        {
           
        }
        public Log4netTraceListener(log4net.ILog log)
        {
            _log = log;
        }
        public override void Write(string message) => _log?.Debug(message);
        public override void WriteLine(string message) => _log?.Debug(message);
    }
