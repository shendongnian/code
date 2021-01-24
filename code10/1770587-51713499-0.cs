    public static class BackGroundWorker
    {
        private static Thread WorkerThread = null;
        private static readonly object WorkerLock = new object();
        private static readonly ManualResetEventSlim ShutdownEvent = new ManualResetEventSlim(false);
        private static ConcurrentDictionary<string, string> backGroundExecutingRequestIds = new ConcurrentDictionary<string, string>();
        public static void Start()
        {
            if (WorkerThread != null)
            {
                return;
            }
            lock (WorkerLock)
            {
                if (WorkerThread != null)
                {
                    return;
                }
                ShutdownEvent.Reset();
                WorkerThread = new Thread(new ThreadStart(WorkerThreadProc));
                WorkerThread.Start();
            }
        }
        public static void Stop()
        {
            if (WorkerThread == null)
            {
                return;
            }
            ShutdownEvent.Set();
            WorkerThread.Join();
            WorkerThread = null;
        }
        private static void WorkerThreadProc() => WorkerThreadProcAsync().Wait();
        private static async Task WorkerThreadProcAsync()
        {
            try
            {
                while (!ShutdownEvent.Wait(0))
                {
                    var ids = backGroundExecutingRequestIds.Take(25)?.Select(item => item.Key)?.ToList();
                    while (ids?.Count > 0)
                    {
                        //// Do the work of calling external Service which takes 12 seconds.
                        ids = Get the Next 25 Ids
                    }
                    await Task.Delay(TimeSpan.FromMilliseconds(100));
                }
            }
            catch(Exception ex)
            {
               ////LogException
            }
        }
    }
}
