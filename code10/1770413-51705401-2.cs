    public class LongRunningService : BackgroundService
    { 
        public LongRunningService()
        {
        }
    
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested && forceStatusChange)
            {
                foreach (var ext in GetExtensions())
                {
                    ext.Status = StatusType.Available;
                }
    
                await Task.Delay(1000, stoppingToken);
            }  
        }
    
        protected override async Task StopAsync (CancellationToken stoppingToken)
        {
            // Run your graceful clean-up actions
        }
    }
