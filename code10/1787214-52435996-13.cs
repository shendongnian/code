    class MyDefaultJobFactory : SimpleJobFactory {
        private readonly IServiceProvider container;
     
        public MyDefaultJobFactory(IServiceProvider container) {
            this.container = container;
        }
     
        public override IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler) {
            IJobDetail jobDetail = bundle.JobDetail;
            Type jobType = jobDetail.JobType;
            try {
                // this will inject any dependencies that the job requires
                return (IJob) this.container.GetService(jobType); 
            } catch (Exception e) {
                var errorMessage = string.Format("Problem instantiating job '{0}'.", jobType.FullName);
                throw new SchedulerException(errorMessage, e);
            }
        }
    }
    
