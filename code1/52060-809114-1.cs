    // Class that represents the Service version of your app
    public class serviceSample : ServiceBase
    {
        protected override void OnStart(string[] args)
        {
            // Run the service version here 
            //  NOTE: If you're task is long running as is with most 
            //  services you should be invoking it on Worker Thread 
            //  !!! don't take to long in this function !!!
            base.OnStart(args);
        }
        protected override void OnStop()
        {
            // stop service code goes here
            base.OnStop();
        }
    }
    
    static class Program
    {
        // The main entry point for the application.
        static void Main(string[] args)
        {
            ServiceBase[] ServicesToRun;
            if ((args.Length > 0) && (args[0] == "/console"))
            {
                // Run the console version here
            }
            else
            {
                ServicesToRun = new ServiceBase[] { new serviceSample () };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
</pre>
