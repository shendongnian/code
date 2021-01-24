    public class SimpleInjectorJobProcessorHostedService : IHostedService, IDisposable
    {
        private readonly Container container;
        private Timer timer;
        public SimpleInjectorJobProcessorHostedService(Container c) => this.container = c;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.timer = new Timer(this.DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }
        private void DoWork(object state)
        {
            // Run operation in a scope
            using (AsyncScopedLifestyle.BeginScope(this.container))
            {
                // Resolve the collection of IMyJob implementations
                foreach (var service in this.container.GetAllInstances<IMyJob>())
                {
                    service.DoWork();
                }
            }
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        public void Dispose() => this.timer?.Dispose();
    }
