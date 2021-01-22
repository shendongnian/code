    namespace YourNamespace
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            static void Main()
            {
    #if DEBUG
                Service1 myService = new Service1();
                myService.OnDebug();
                System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
    #else
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
    			{
    				new Service1()
    			};
                ServiceBase.Run(ServicesToRun);
    #endif
            }
        }
    }
