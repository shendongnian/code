    public class QuartzServer
        {
    
            private static IScheduler _scheduler;
    
    
            [MethodImpl(MethodImplOptions.Synchronized)]
            public static void Start()
            {
                _scheduler = StdSchedulerFactory.GetDefaultScheduler().GetAwaiter().GetResult();
                Load();
                _scheduler.Start();
            }
    
            [MethodImpl(MethodImplOptions.Synchronized)]
            public static void Stop()
            {
                _scheduler.Shutdown(true);
            }
            
            [MethodImpl(MethodImplOptions.Synchronized)]
            private static void Load()
            {
                JobCreator.CreateJob<MailJob>(new JobInfo
                {
                    JobName = "MailJob",
                    TriggerName = "MainJobTrg",
                    GroupName = "MainJobGroup",
                    DataParamters = null,
                    CronExpression = "paste here cronmaker time planning string" 
                }, ref _scheduler);   
               // Define job Daily , weekly and mounthly     
            }
    }
