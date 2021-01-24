    public class SkipConcurrentExecutionAttribute : JobFilterAttribute, IServerFilter
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly int _timeoutInSeconds;
        public SkipConcurrentExecutionAttribute(int timeoutInSeconds)
        {
            if (timeoutInSeconds < 0) throw new ArgumentException("Timeout argument value should be greater that zero.");
            _timeoutInSeconds = timeoutInSeconds;
        }
        public void OnPerforming(PerformingContext filterContext)
        {
            var resource = $"{filterContext.BackgroundJob.Job.Type.FullName}.{filterContext.BackgroundJob.Job.Method.Name}.{filterContext.BackgroundJob.Id}";
            var timeout = TimeSpan.FromSeconds(_timeoutInSeconds);
            try
            {
                var distributedLock = filterContext.Connection.AcquireDistributedLock(resource, timeout);
                filterContext.Items["DistributedLock"] = distributedLock;
            }
            catch (Exception)
            {
                filterContext.Canceled = true;
                logger.Warn("Cancelling run for {0} job, id: {1} ", resource, filterContext.BackgroundJob.Id);
            }
        }
        public void OnPerformed(PerformedContext filterContext)
        {
            if (!filterContext.Items.ContainsKey("DistributedLock"))
            {
                throw new InvalidOperationException("Can not release a distributed lock: it was not acquired.");
            }
            var distributedLock = (IDisposable)filterContext.Items["DistributedLock"];
            distributedLock.Dispose();
        }
    }
