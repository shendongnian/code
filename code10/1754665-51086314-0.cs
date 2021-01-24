        class logger
    {
        static readonly object _logSync = new object();
        
        public void Log(string message)
        {
            var m = $"{DateTime.Now.ToString("HH:mm:ss")}; {message}{Environment.NewLine}";
            lock(_logSync)
            {
                File.AppendAllText(@"C:\temp\test.txt", m);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ServiceBase.Run(new TestHangService());
        }
    }
    class TestHangService : ServiceBase
    {
        static readonly object _sync = new object();
        private logger _log;
        public TestHangService()
        {
            _log = new logger();
        }
        protected override void OnStart(string[] args)
        {
            _log.Log("OnStart");
            
            lock(_sync)
            {
                _log.Log("OnStart in lock");
                Thread.Sleep(30 * 1000);
                _log.Log("OnStart exit lock");
            }
        }
        protected override void OnStop()
        {
            _log.Log("OnStop");
        }
    }
