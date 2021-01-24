     public class QuartzJobFactory : IJobFactory
    {
        protected readonly IServiceProvider serviceProvider;
        private ConcurrentDictionary<IJob, IServiceScope> scopes = new ConcurrentDictionary<IJob, IServiceScope>();
        
        public QuartzJobFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        // instantiation of new job
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try {
                var scope = serviceProvider.CreateScope();
                var job = scope.ServiceProvider.GetRequiredService(bundle.JobDetail.JobType) as IJob;
                scopes.TryAdd(job, scope);
                
                return job;
            }
            catch (Exception ex) {
                throw;
            }
        }
        // executes when job is complete
        public void ReturnJob(IJob job)
        {
            try {
                (job as IDisposable)?.Dispose();
                if (scopes.TryRemove(job, out IServiceScope scope))
                    scope.Dispose();
            }
            catch (Exception ex) {
            }
        }
    }
