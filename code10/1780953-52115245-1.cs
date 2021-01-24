    using Common.Logging;
    using Quartz;
    using System;
    using System.Threading.Tasks;
    
    namespace MyNamespace
    {
        [DisallowConcurrentExecution]
        public class MyJob : IJob
        {
            private readonly ILog _log = LogManager.GetLogger(typeof(MyJob));
    
            public Task Execute(IJobExecutionContext context)
            {
                var myTask = new Task(() =>
                {
                    try
                    {
                        _log.Info("Start!" + context.JobDetail.Key.Name);
    
                        if (context.RefireCount < 3)
                        {
                            _log.Info("Fails! " + context.RefireCount + " " + context.JobDetail.Key.Name);
                            throw new NotImplementedException();
                        }
    
                        _log.Info("Ok! " + context.RefireCount + " " + context.JobDetail.Key.Name);
                    }
                    catch (Exception ex)
                    {
                        throw new JobExecutionException(ex) { RefireImmediately = true };
                    }
                });
                myTask.Start();
                return myTask;
    
            }
    
    
        }
    }
