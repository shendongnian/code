    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ...
            ScheduledTasks.JobScheduler.Start();
            ...
        }
    }
