    static void Main()
    {
    #if DEBUG
            var MainService = new MainService();
            MainService.OnDebug();
    
    #else
    
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new MainService()
            };
            ServiceBase.Run(ServicesToRun);
    #endif
    }
