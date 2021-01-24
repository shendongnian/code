    public class MyHostedService : IHostedService
    {
        private readonly MyHostedServiceDecorator
            _decorator;
        public MyHostedService(MyHostedServiceDecorator decorator)
        {
            _decorator = decorator;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // base StartAsync logic ...
            await _decorator.StartAsync(cancellationToken);
        }
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            // base StopAsync logic ...
            await _decorator.StopAsync(cancellationToken);
        }
    }
