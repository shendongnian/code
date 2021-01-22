    public abstract class JobBase : IJob
    {
        protected JobBase()
        {
        }
    
        public abstract void ExecuteJob(JobExecutionContext context);
    
        public void Execute(JobExecutionContext context)
        {
            string logSource = context.JobDetail.FullName;
    
            try
            {
                ExecuteJob(context);
            }
            catch (Exception e)
            {
               // Log exception
            }
        }
    }
