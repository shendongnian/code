    public static class QueryThread
    {
        private static SyncEvents _syncEvents = new SyncEvents();
        private static Queue<Delegate> _queryQueue = new Queue<Delegate>();
        static Producer queryProducer;
        static Consumer queryConsumer;
        public static void init()
        {
            queryProducer = new Producer(_queryQueue, _syncEvents);
            queryConsumer = new Consumer(_queryQueue, _syncEvents);
            Thread producerThread = new Thread(queryProducer.ThreadRun);
            Thread consumerThread = new Thread(queryConsumer.ThreadRun);
            producerThread.IsBackground = true;
            consumerThread.IsBackground = true;
            producerThread.Start();
            consumerThread.Start();
        }
        public static void Enqueue(Delegate item)
        {
            queryProducer.secondQueue.Enqueue(item);
        }
    }
