    using log4net;
    namespace LogIssue
    {
        internal class WindowsService
        {
            static ILog _log = LogManager.GetLogger(typeof(WindowsService));
    
            internal bool OnStart() {
                new Worker().DoWork();
                return true;
            }
    
            internal bool OnStop() => true;
        }
    }
