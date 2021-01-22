    public class Worker
    {
        private readonly Thread[] _threads;
        private readonly object _locker = new object();
        private readonly TimeSpan _tooFastSuspensionSpan;
        private DateTime _lastSuspensionTime;
    
        public Worker(int numThreads, TimeSpan tooFastSuspensionSpan)
        {
            _tooFastSuspensionSpan = tooFastSuspensionSpan;
            _threads = Enumerable.Repeat(new ThreadStart(DoWork), numThreads)
                                 .Select(ts => new Thread(ts))
                                 .ToArray();
        }
    
        public void Run()
        {
            foreach (var thread in _threads)
            {
                thread.Start();
            }
        }
    
        private void DoWork()
        {
            while (!IsWorkComplete())
            {
                try
                {
                    // Do work here
    
                }
                catch (TooFastException)
                {
                    SuspendAll();
                }
            }
    
        }
    
        private void SuspendAll()
        {
            lock (_locker)
            {
                // We don't want N near-simultaneous failures causing a sleep-duration of N * _tooFastSuspensionSpan
                // 1 second is arbitrary. We can't be deterministic about it since we are forcefully suspending threads
                var now = DateTime.Now;
                if (now.Subtract(_lastSuspensionTime) < _tooFastSuspensionSpan + TimeSpan.FromSeconds(1))
                    return;
    
                _lastSuspensionTime = now;
    
                var otherThreads = _threads.Where(t => t.ManagedThreadId != Thread.CurrentThread.ManagedThreadId).ToArray();
    
                foreach (var otherThread in otherThreads)
                    otherThread.Suspend();
    
                Thread.Sleep(_tooFastSuspensionSpan);
    
                foreach (var otherThread in otherThreads)
                    otherThread.Resume();
            }
        }
    
    }
