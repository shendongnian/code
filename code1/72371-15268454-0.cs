    public class BackgroundTask : IDisposable
    {
        private readonly CancellationTokenSource cancellationTokenSource;
        private bool stop;
        public BackgroundTask()
        {
            this.cancellationTokenSource = new CancellationTokenSource();
            this.stop = false;
        }
        public void Stop()
        {
            this.stop = true;
            this.cancellationTokenSource.Cancel();
        }
        public void Dispose()
        {
            this.cancellationTokenSource.Dispose();
        }
        private void ThreadedWork(object state)
        {
            using (var syncHandle = new ManualResetEventSlim())
            {
                while (!this.stop)
                {
                    syncHandle.Wait(TimeSpan.FromMinutes(15), this.cancellationTokenSource.Token);
                    if (!this.cancellationTokenSource.IsCancellationRequested)
                    {
                        // DoWork();
                    }
                }
            }
        }
    }
