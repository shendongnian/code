    public class MyHostedService: IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(() => SomeInfinityProcess(cancellationToken));
            return Task.CompletedTask;
        }
        public void SomeInfinityProcess(CancellationToken cancellationToken)
        {
            for (; ; )
            {
                Thread.Sleep(1000);
                if (cancellationToken.IsCancellationRequested)
                    break;
            }
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
