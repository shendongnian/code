    public class ParallelEmailSender : IDisposable
    {
        private readonly BlockingCollection<string> blockingCollection;
    
        public ParallelEmailSender(int threadsCount)
        {
            blockingCollection = new BlockingCollection<string>(new ConcurrentQueue<string>());
            for (int i = 0; i < threadsCount; i++)
            {
                Task.Factory.StartNew(SendInternal);
            }
        }
    
        public void Send(string message)
        {
            blockingCollection.Add(message);
        }
    
        private void SendInternal()
        {
            foreach (string message in blockingCollection.GetConsumingEnumerable())
            {
                // send method
            }
        }
    
        public void Dispose()
        {
            blockingCollection.CompleteAdding();
        }
    }
