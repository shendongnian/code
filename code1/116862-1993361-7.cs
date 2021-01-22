    public class MyClass
    {
        private ILogger logger;
    
        public myClass(ILogger logger)
        {
            this.logger = logger;
        }
    
        public void DoSomething()
        {
            // Now if DoSomething needs to call logging it can call what ever ILogger was passed in
            this.logger.Log("We did something");
        }
    }
