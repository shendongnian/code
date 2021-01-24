    public static void AddFluentSchedulerJob<TJob>(
        this Container container, Action<Schedule> schedule)
        where TJob : class, IMyJob
    {
        container.Register<TJob>();
        JobManager.AddJob(() =>
            {
                using (ThreadScopedLifestyle.BeginScope(container))
                {
                    container.GetInstance<TJob>().Run();
                }
            },
            schedule);
    }
