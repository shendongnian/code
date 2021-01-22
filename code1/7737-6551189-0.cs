        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new MyService(),
                new MyServiceDebug()
			};
            ServiceBase.Run(ServicesToRun);
        }
