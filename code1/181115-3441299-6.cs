    public class AwesomeLoggingPlugin : IWatcherPluginBase
    {
        private static readonly ILog _log = 
            LogProvider.GetLogger<AwesomeLoggingPlugin> ();
        public AwesomeLoggingPlugin ()
        {
            _log.Debug ("Instantiated.");
        }
    }
