    public class ListnerBackgroundService : BackgroundService
    {
        private readonly ListnerService service;
    
        public ListnerBackgroundService(ListnerService service)
        {
            this.service = service;
        }
    
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            service.Listen();
            return Task.CompletedTask;
        }
    }
