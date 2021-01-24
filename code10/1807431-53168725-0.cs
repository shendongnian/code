    public class PushJob : IJob
    {
        private static IContainer _container;
        public async Task Execute(IJobExecutionContext context)
        {                      
          Register();
          DoWork();
        }
    }
