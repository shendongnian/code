        private static readonly object _syncRoot = new object();
        protected override void OnStop()
        {
            lock (_syncRoot) 
            {
                _workerThread.Abort();
            }
        }
        static void DoWork()
        {
            int sleepMinutes = 30;
            while (true)
            {
                 lock (_syncRoot) 
                 {
                     ActualWorkDoneHere();
                 }
                 System.Threading.Thread.Sleep(new TimeSpan(0, sleepMinutes, 0));
            }
        }
