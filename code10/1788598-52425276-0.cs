    public class Runner : IHostedService, IDisposable
    {
        private Container _container;
        public Runner()
        {
            _container = new Container();
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Bootstrapper.Bootstrap(_container);
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _container.Dispose();
            _container = null;
        }
    }
