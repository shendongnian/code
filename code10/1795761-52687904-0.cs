    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
          #if DEBUG
            var Service = new WindowsService1();
            Service.OnDebug();
          #else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new WindowsService1()
            };
            ServiceBase.Run(ServicesToRun);
          #endif
        }
    }
