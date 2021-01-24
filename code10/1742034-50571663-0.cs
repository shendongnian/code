    class Foo
    {
        private static ILog _logger = LogManager.Instance.GetLogger(typeof(Foo));
        public void DoSomething()
        {
            _logger.Info("Doing something"); 
        }
    }
