    public IEnumerable<QuartzJob> GetQuartzInfo(IScheduler scheduler)
    {
        IEnumerable<QuartzJob> jobs = scheduler.JobGroupNames.SelectMany(   // Using SelectMany because there is an IEnumerable<QuartzJob> for each group and we want to flatten that.
            groupName => scheduler.GetJobNames(groupName).Select(  // Returns an IEnumerable<QuartzJob> for each group name found.
                jobName => 
                    // We're doing a lot in this new but essentially it creates a new QuartzJob for each jobName/groupName combo
                    new QuartzJob(new Guid(groupName), new Guid(jobName),
                        scheduler.GetTriggersOfJob(jobName, groupName).Select(trigger => trigger.Name)  // This transforms the GetTriggersOfJob into an IEnumerable<string> for use in the constructor of QuartzJob
                        ))); 
        return new List<QuartzJob>(jobs);
    }
