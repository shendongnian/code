    class MyClass
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    
        public void MyMethod()
        {
            Logger.Debug("Debug message"); // different levels are TRACE,INFO,DEBUG,WARN,FATAL,ERROR
        }
    }
