           public class RecureHostedService : IHostedService, IDisposable
         {
        private readonly ILogger _log;
        private Timer _timer;
        public RecureHostedService(ILogger<RecureHostedService> log)
        {
            _log = log;
        }
    
        public void Dispose()
        {
            _timer.Dispose();
        }
    
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _log.LogInformation("RecureHostedService is Starting");
            _timer = new Timer(DoWork,null,TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }
    
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _log.LogInformation("RecureHostedService is Stopping");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        private void DoWork(object state)
        {
            _log.LogInformation("Timed Background Service is working.");
        }
        }
