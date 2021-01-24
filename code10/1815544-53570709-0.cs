    public class AutofacJobFactory : IJobFactory {
        private readonly ILifetimeScope _container;
        private static readonly ConcurrentDictionary<IJob, ILifetimeScope>
            _childScopesMap = new ConcurrentDictionary<IJob, ILifetimeScope>();
    
        public AutofacJobFactory(ILifetimeScope container) {
            _container = container;
        }
    
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler) {
            var childScope = _container.BeginLifetimeScope();            
            var job = (IJob)childScope.Resolve(bundle.JobDetail.JobType);
            _childScopesMap.TryAdd(job, childScope);
            return job;
        }
    
        public void ReturnJob(IJob job) {
            if (!_childScopesMap.TryRemove(job, out var scope))
                return;
            try {
                scope.Dispose();
            } catch (Exception ex) {
                // TODO: handle/log 
            }
        }
    }
