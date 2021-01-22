    public virtual void Execute(IJobExecutionContext context)
    {
        int i = 0;
        while (i++ < 100)
        {
            context.JobDetail.JobDataMap["progress"] = i;
            Thread.Sleep(1000);
        }
    }
