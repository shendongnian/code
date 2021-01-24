    public class LoopingService
    {
        private CancellationTokenSource cts;
        async Task Worker(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await ...
            }
        }
        public async Task Start()
        {
            this.cts = new CancellationTokenSource();
            await this.Worker(cts.Token).ConfigureAwait(false);
        }
        public void Stop()
        {
            this.cts.Cancel();
            this.cts.Dispose();
        }
    }
