    public interface IDearJob : IJob { }
    
    public interface DearJob : IDearJob 
    {
        private readonly ISomeService service;
    
        public DearJob(ISomeService service)
        {
            this.service = service;
        }
    
        public async Task Execute(IJobExecutionContext context) 
        {
            // retrieve context if you need
            await this.service.DoSomethingAsync(/*params*/);
        }
    }
