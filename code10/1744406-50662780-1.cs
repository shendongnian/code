    public class SomeJobScheduler
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
            IJobDetail job = JobBuilder.Create<SomeJob>().Build();
            ITrigger trigger = TriggerBuilder.Create()
            .WithCronSchedule("0 05 8 ? * MON-FRI *") //This expression to schedule your job Mon-Fri 8.05 AM
            .Build();
           
            scheduler.ScheduleJob(job, trigger);
        }
    }
