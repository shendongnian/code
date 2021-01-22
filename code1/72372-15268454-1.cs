    using System;
    using System.Threading;
    public class BackgroundTask : IDisposable
    {
        private readonly ManualResetEventSlim threadedWorkEndSyncHandle;
        private readonly CancellationTokenSource cancellationTokenSource;
        private bool stop;
        public BackgroundTask()
        {
            this.threadedWorkEndSyncHandle = new ManualResetEventSlim();
            this.cancellationTokenSource = new CancellationTokenSource();
            this.stop = false;
        }
        public void Dispose()
        {
            this.stop = true;
            this.cancellationTokenSource.Cancel();
            this.threadedWorkEndSyncHandle.Wait();
            this.cancellationTokenSource.Dispose();
            this.threadedWorkEndSyncHandle.Dispose();
        }
        private void ThreadedWork(object state)
        {
            try
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
            finally
            {
                this.threadedWorkEndSyncHandle.Set();
            }
        }
    }
