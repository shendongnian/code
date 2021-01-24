    [...]
    public override void PostInitialize()
    {
        var recurrentJobs = IocManager.Resolve<NotificationJob>();
        RecurringJob.RemoveIfExists("JobName");
        RecurringJob.AddOrUpdate("JobName", () => recurrentJobs.CheckTickets(), Cron.Minutely);
    }
