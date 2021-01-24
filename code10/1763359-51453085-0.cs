    public abstract class WorkerService<T> : IWorkerService where T : class
    {
        private readonly ISession _session;
        private readonly IPeriodService _periodService;
        private readonly IGService _gService;
        private readonly IIntegrationService _integrationService;
        public OutlookIntegrationWorkerService(...)
        {
            ...
        }
        public enum emunType
        {
            Class1ToExport = 1,
            Class2ToExport = 2,
        }
        protected abstract void somefunction<T>(Guid id, IJobCancellationToken 
        cancellationToken);
    }
    public class WorkerService_Class1 : WorkerService<Class1>
    {
        protected override void somefunction<T>(Guid id, IJobCancellationToken 
        cancellationToken)
        {
            //do work
        }
    }
    public class WorkerService_Class2 : WorkerService<Class2>
    {
        protected override void somefunction<T>(Guid id, IJobCancellationToken 
       cancellationToken)
        {
            //do work
        }
    }
