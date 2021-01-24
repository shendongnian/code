        // Grab the Scheduler instance from the Factory
        NameValueCollection props = new NameValueCollection
        {
            { "quartz.serializer.type", "binary" }
        };
        var factory = new StdSchedulerFactory(props);
        var scheduler = await factory.GetScheduler();
        await scheduler.Start();
        var job = JobBuilder.Create<CleanExpiredJob>().Build();
        // Add your dictionary here
        // Notice: Keep the same name as the property in the job for injection
        job.JobDataMap["Items"] = Items;
        // Set the job to run every 10 seconds
        var trigger = TriggerBuilder.Create()
                        .StartNow()
                        .WithSimpleSchedule(x => x
                            .WithIntervalInSeconds(1)
                            .RepeatForever())
                        .Build();
        scheduler.ScheduleJob(job, trigger);
