    static void Main()
    {
    #if !DEBUG
        ServiceBase[] servicesToRun = new ServiceBase[]
        {
            new Scheduler()
        };
        ServiceBase.Run(servicesToRun);
        
    #else
        Scheduler service = new Scheduler();
        service.ScheduleService();
        Thread.Sleep(Timeout.Infinite);
    #endif
    }
