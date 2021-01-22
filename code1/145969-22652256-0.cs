    #if DEBUG
        MyService myService = new MyService();
        myService.OnDebug();
        System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
    #else
        ServiceBase[] ServicesToRun;
        ServicesToRun = new ServiceBase[]
        {
            new MyService()
        };
        ServiceBase.Run(ServicesToRun);
    #endif
