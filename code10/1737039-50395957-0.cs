    public class SimpleInjectorJobProcessorHostedService 
        : IHostedService, IDisposable
    {
        private readonly Container _container;
        private Timer _timer;
        public TimedHostedService(Container container)
        {
            _container = container;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }
        private void DoWork(object state)
        {
            using (AsyncScopedLifestyle.BeginScope(_container))
            {        
                foreach (var service in _container.GetAllInstances<IMyJob>())
                    service.DoWork();
            }
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        public void Dispose() => _timer?.Dispose();
    }
