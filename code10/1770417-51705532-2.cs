    public class PollingService : BackgroundService
    {
        private readonly ILogger _logger;
        public PollingService(ILogger<PollingService> logger)
        {
            _logger = logger;
        }
        protected async override Task ExecuteAsync(
            CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await DoSomething(cancellationToken);
                    await Task.Delay(1000,cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, 
                       $"Error occurred executing {nameof(workItem)}.");
                }
            }
            _logger.LogInformation("Queued Hosted Service is stopping.");
        }        
    }
