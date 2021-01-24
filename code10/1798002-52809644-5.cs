    public interface IService {
        Task Start();
    }
    public class Service : IService {
        private readonly IJobFactory jobFactory;
        private readonly ILog log;
        private readonly ISchedulerFactory schedulerFactory;
        public Service(IJobFactory jobFactory, ISchedulerFactory schedulerFactory, ILog log) {
            this.jobFactory = jobFactory;
            this.schedulerFactory = schedulerFactory;
            this.log = log;
        }
        public async Task Start() {
            IScheduler scheduler = await schedulerFactory.GetScheduler();
            scheduler.JobFactory = jobFactory;
            IJobDetail job = JobBuilder.Create()
               .OfType<SimpleJob>()
               .Build();
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(3)
                    .RepeatForever())
                .Build();
            await scheduler.ScheduleJob(job, trigger);
            await scheduler.Start();
            log.Debug("Scheduler started");
        }
    }
