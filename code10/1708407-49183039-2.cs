    public class Message { }
    public class BlockTester
    {
        //Could be removed
        private static TransformBlock<Message, Message> _worker;
        public static async Task StartAsync()
        {
            //Could be removed
            _worker = new TransformBlock<Message, Message>(s => s);
            var processor = new ActionBlock<Message>(x => ProcessMessage(x));
            _worker.LinkTo(processor, new DataflowLinkOptions { PropagateCompletion = true });
            foreach (var value in Enumerable.Range(0, 100).Select(_ => new Message()))
            {
                _worker.Post(value);
            }
            //_worker.Complete();
            await processor.Completion;
        }
        private static ConcurrentBag<Message> itemsRecieved = new ConcurrentBag<Message>();
        public static void ProcessMessage(Message x)
        {
            itemsRecieved.Add(x);
            if (itemsRecieved.Count > 25) _worker.Complete();
            //process the message
            //log the message etc.
        }
    }
