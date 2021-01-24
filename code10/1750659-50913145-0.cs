    public class ProducerConsumer
    {
        private ActionBlock<int> Consumer { get; }
        public ProducerConsumer()
        {
            Consumer = new ActionBlock<int>(x => Process(x));            
        }
        public async Task Start()
        {
            var producer1Tasks = Producer1();
            var producer2Tasks = Producer2();
            await Task.WhenAll(producer1Tasks.Concat(producer2Tasks));
            Consumer.Complete();
            await Consumer.Completion;
        }
        private void Process(int data)
        {
            // process
        }
        private IEnumerable<Task> Producer1() => Enumerable.Range(0, 100).Select(x => Consumer.SendAsync(x));
        private IEnumerable<Task> Producer2() => Enumerable.Range(0, 100).Select(x => Consumer.SendAsync(x));
    }
