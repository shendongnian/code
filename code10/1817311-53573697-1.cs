    public class MyClass
    {
        public long TotalOutstandingRequests;
        private readonly ILogger _logger;
        //some incrementing, decrementing code here
        public MyClass(ILogger logger)
        {
            _logger = logger;
        }
        public void AddRequest()
        {
            Interlocked.Increment(ref TotalOutstandingRequests);
            _logger.Debug("New request here!");
        }
    }
