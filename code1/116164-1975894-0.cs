    public static void Execute(this IJob job)
    {
        try
        {
            job.Run();
        }
        finally
        {
            var disposableJob = job as IDisposable;
            if(disposableJob != null)
            {
                disposableJob.Dispose();
            }
        }
    }
