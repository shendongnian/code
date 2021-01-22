    class Program
    {
        static void Main(string[] args)
        {
            Bootstrap.Init(args, ServiceSetup);
        }
    
        static void ServiceSetup(SchedulingService service)
        {
            service.Hourly().Run<MyFirstJob>();
            service.Daily().Run<MySecondJob>();
        }
    }
