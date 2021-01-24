    public class SimpleInjectorJobProcessorHostedService : IHostedService, IDisposable
    {
        private readonly Container _container;
        private Timer _timer;
        public SimpleInjectorJobProcessorHostedService(Container c) => _container = c;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(this.DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }
        private void DoWork(object state)
        {
            // Run operation in a scope
            using (AsyncScopedLifestyle.BeginScope(_container))
            {
                // Resolve the collection of IMyJob implementations
                foreach (var service in _container.GetAllInstances<IMyJob>())
                {
                    service.DoWork();
                }
            }
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        public void Dispose() => _timer?.Dispose();
    }
