    class Program
    {
        static void Main(string[] args)
        {
            EnqueuedState queue = new EnqueuedState("myQueueName");
            new BackgroundJobClient().Create<Program>(c => c.DoWork(), queue);
        }
        public void DoWork()
        {
        }
    }
