    public static async Task RegisterQuartz(Container container)
    {
        ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
        IScheduler scheduler = await schedulerFactory.GetScheduler();
        IJobFactory jobFactory = new SomeJobFactory(container);
        scheduler.JobFactory = jobFactory;
    
        container.RegisterInstance(schedulerFactory);
        container.RegisterInstance(jobFactory);
        container.RegisterInstance(scheduler);
        container.Register<IDearJob, DearJob>();
    }
