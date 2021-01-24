    public static class FooAdded
    {
        [FunctionName("FooAdded")]
        public static void Run([QueueTrigger("tracker-readings")]string myQueueItem, TraceWriter log)
        {
            log.Info($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
