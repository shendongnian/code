    using log4net;
    using System.Timers;
    
    namespace LogIssue
    {
        internal class WindowsService
        {
            static ILog _log = LogManager.GetLogger(typeof(WindowsService));
            readonly Timer _timer = new Timer(1000);
    
            public WindowsService() =>  _timer.Elapsed += (s, e) => new Worker().DoWork();
            
            internal void OnStart() =>  _timer.Start();
    
            internal void OnStop() => _timer.Stop();
        }
    }
