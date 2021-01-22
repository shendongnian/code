    public IEnumerable<QuartzJob> GetQuartzInfo(IScheduler scheduler)
    {
        IEnumerable<QuartzJob> jobs = from groupName in scheduler.JobGroupNames
                                      from jobName in scheduler.GetJobNames(groupName) // stacking the two froms is the equivalent of SelectMany because the first select is defaulted as the result of the second.
                                      select new QuartzJob(new Guid(groupName), new Guid(jobName),
                                          // this sub-select is to get just the IEnumerable<string> of trigger names needed for the constructor.
                                          (from trigger in scheduler.GetTriggersOfJob(jobName, groupName)
                                           select trigger.Name));
        return new List<QuartzJob>(jobs);
    }
