    public abstract class MyHostedServiceDecorator : IHostedService
    {
        private readonly MyHostedServiceDecorator _next;
        protected MyHostedServiceDecorator(MyHostedServiceDecorator next)
        {
            _next = next;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await StartAsyncInternal(cancellationToken);
            if (_next != null)
            {
                await _next.StartAsync(cancellationToken);
            }
        }
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await StopAsyncInternal(cancellationToken);
            if (_next != null)
            {
                await StopAsync(cancellationToken);
            }
        }
        protected abstract Task StartAsyncInternal(CancellationToken token);
        protected abstract Task StopAsyncInternal(CancellationToken token);
    }
