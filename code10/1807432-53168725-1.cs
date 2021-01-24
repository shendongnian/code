    public class PushJob : IJob
    {
        private IContainer _container;
        public async Task Execute(IJobExecutionContext context)
        {                      
          Register();
          DoWork();
        }
    }
