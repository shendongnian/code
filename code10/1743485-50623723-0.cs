    foreach (var jobType in jobTypes)
    {
        _schedule.Every(TimeSpan.FromSeconds(30), () =>
        {
            using (var scope = _lifetimeScope.BeginLifetimeScope(builder =>
            {
                builder.RegisterType(jobType).As<IJob>();
            }))
            {
                var job = scope.Resolve<IJob>();
                job.Run();
            }
        });
    }
