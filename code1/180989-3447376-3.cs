    public interface IWorkProvider
    {
        bool ShouldStop { get; }
        long? GetWork();
    }
    public class Program : IWorkProvider
    {
        // Main Thread uses to indicate to New Thread to stop
        private static bool _shouldStop = false;
        // Main Thread passes ongoing updates to New Thread via this queue
        private static ConcurrentQueue<long> _workQueue = new ConcurrentQueue<long>();
        public bool ShouldStop { get { return _shouldStop; } }
        public long? GetWork()
        {
            long currentValue;
            bool worked = _workQueue.TryDequeue(out currentValue);
            if (worked)
                return currentValue;
            return null;
        }
    }
 
    public class Worker
    {
        private long _results;
        private readonly IWorkProvider _workProvider;
        public long Results { get { return _results; }}
        public Worker(IWorkProvider workProvider)
        {
            _workProvider = workProvider;
        }
        public void DoWork()
        {
            // Update Summary
            while (!_workProvider.ShouldStop)
            {
                long? work = _workProvider.GetWork();
                if (work.HasValue)
                {
                    _results += work.Value;
                    Debug.WriteLine("DeQueue: " + work.Value);
                }
                else
                {
                    Thread.Sleep(10);
                }
            }
        }
    }
