    class MyClass
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    
        public void MyMethod()
        {
            // available logging levels TRACE,INFO,DEBUG,WARN,ERROR, FATAL
            Logger.Debug("Debug message"); 
        }
    }
