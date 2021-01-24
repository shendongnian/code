    public class HostedServiceDecorator<T> : IHostedService where T : IHostedService
    {
        private readonly IHostedService _next;
        public HostedServiceDecorator(T target)
        {
            _next = target;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            if (_next != null)
            {
                await _next.StartAsync(cancellationToken);
            }
        }
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_next != null)
            {
                await _next.StopAsync(cancellationToken);
            }
        }
    }
