    using Quartz;
    using Quartz.Impl;
        protected void Application_Start(object sender, EventArgs e)
        {
            DateTimeOffset startTime = DateBuilder.FutureDate(1, IntervalUnit.Hour);
            IJobDetail job = JobBuilder.Create<Quartz>()
                                       .WithIdentity("job1")
                                       .Build();
            ITrigger trigger = TriggerBuilder.Create()
                                             .WithIdentity("trigger1")
                                             .StartAt(startTime)
                                             .WithSimpleSchedule(x => x.WithIntervalInSeconds(10).WithRepeatCount(2))
                                             .Build();
            ISchedulerFactory sf = new StdSchedulerFactory();
            IScheduler sc = sf.GetScheduler();
            sc.ScheduleJob(job, trigger);
            sc.Start();
        }
