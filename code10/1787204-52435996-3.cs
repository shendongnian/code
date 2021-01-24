    class MyDefaultJobFactory : SimpleJobFactory {
        private readonly IServiceProvider container;
     
        public MyDefaultJobFactory(IServiceProvider container) {
            this.container = container;
        }
     
        public override IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler) {
            try {
                // this will inject any dependencies that the job requires
                return (IJob) this.container.GetService(bundle.JobDetail.JobType); 
            } catch (Exception e) {
                throw new SchedulerException(string.Format("Problem while instantiating job '{0}' from the your default Job Factory.", bundle.JobDetail.Key), e);
            }
        }
    }
    
