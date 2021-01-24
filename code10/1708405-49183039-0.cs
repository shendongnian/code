    public class BlockTester
    {
        //Could be removed
        private static TransformBlock<int, int> _worker;
        public static async Task StartAsync()
        {
            //Could be removed
            _worker = new TransformBlock<int, int>(s => s + s);
            var processor = new ActionBlock<int>(x => ProcessMessage(x));
            _worker.LinkTo(processor, new DataflowLinkOptions { PropagateCompletion = true });
            foreach (var value in Enumerable.Range(0, 100))
            {
                _worker.Post(value);
            }
            //_worker.Complete();
            await processor.Completion;
        }
        private static int itemsRecieved = 0;
        public static void ProcessMessage(int x)
        {
            Interlocked.Increment(ref itemsRecieved);
            if (itemsRecieved > 25) _worker.Complete();
            //process the message
            //log the message etc.
        }
    }
