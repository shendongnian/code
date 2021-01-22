    public class AnotherAwesomeLoggingPlugin : IWatcherPluginBase
    {
        private readonly ILog _log = null;
        public AnotherAwesomeLoggingPlugin (ILog log)
        {
            _log = log;
            _log.Debug ("Instantiated.");
        }
    }
