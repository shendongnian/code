    public class TestService : HostedService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
    
        public TestService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;          
        }
    
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                IMyService myScopedService = scope.ServiceProvider.GetRequiredService<IMyService>();
    
                while (!cancellationToken.IsCancellationRequested)
                {
                    await myScopedService.Execute();
                    await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
                }
            }
           
        }
    }
