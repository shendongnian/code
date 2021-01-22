    public sealed class LogState : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
            Guid instanceId = context.WorkflowInstanceId;
            var connection = ConfigurationManager.ConnectionStrings["ConnectionString"];
            
            WorkflowInstanceProxy proxy = context.GetExtension<WorkflowInstanceInfo>().GetProxy();
            //...
        }
        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            metadata.AddDefaultExtensionProvider<WorkflowInstanceInfo>(() => new WorkflowInstanceInfo());
        }
        public class WorkflowInstanceInfo : IWorkflowInstanceExtension
        {
            WorkflowInstanceProxy proxy;
            public IEnumerable<object> GetAdditionalExtensions()
            {
                yield break;
            }
            public void SetInstance(WorkflowInstanceProxy instance)
            {
                this.proxy = instance;
            }
            public WorkflowInstanceProxy GetProxy() { return proxy; }
        }
