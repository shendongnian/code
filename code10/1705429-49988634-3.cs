    using NLog;
    using Quartz;
    using Quartz.Spi;
    using System;
    
    namespace My.Dear.App.Infrastructure
    {
    
        public class SomeJobFactory : IJobFactory
        {
            private static ILogger logger = LogManager.GetCurrentClassLogger();
            private readonly IServiceProvider serviceProvider;
    
            public DexJobFactory(IServiceProvider serviceProvider)
            {
                this.serviceProvider = serviceProvider;
            }
    
            public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
            {
                try
                {
                    IJobDetail jobDetail = bundle.JobDetail;
                    Type jobType = jobDetail.JobType;
                    logger.Debug($"Producing instance of Job '{jobDetail.Key}', class={jobType.FullName}");
    
                    return serviceProvider.GetService(jobType) as IJob;
                }
                catch (Exception ex)
                {
                    logger.Error(ex, Constants.ErrorAt, nameof(IJobFactory.NewJob));
                    throw new SchedulerException($"Problem instantiating class '{bundle.JobDetail.JobType.FullName}'", ex);
                }
            }
    
            public void ReturnJob(IJob job)
            {
                var disposable = job as IDisposable;
                disposable?.Dispose();
            }
        }
    }
