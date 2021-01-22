    public abstract Thread
    {
        protected Thread()
        {
        }
        public void Run()
        {
            LogStart();
            DoRun();
            LogEnd();
        }
        protected abstract DoRun();
    
        private void LogStart()
        {
             Console.Write("Starting Thread Run");
        }
        private void LogEnd()
        {
             Console.Write("Ending Thread Run");
        }
    }
    public class HelloWorldThread : Thread
    {
        public HelloWorldThread()
        {
        }
        protected override DoRun()
        {
            Console.Write("Hello World");
        }
    }
    
  
