    static void Main()
    {
        ServiceBase[] servicesToRun;
        servicesToRun = new ServiceBase[] 
        {
            new MyService()
        };
        if (Environment.UserInteractive)
        {
            RunInteractive(servicesToRun);
        }
        else
        {
            ServiceBase.Run(servicesToRun);
        }
    }
