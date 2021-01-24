    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    public class LatencySimulator {
        public enum SimulatorType { UP, DOWN };
        public SimulatorType type;
        public int latency = 0;
        public int maxConsumers = 50;
        public BlockingCollection<byte[]> inputQueue = new BlockingCollection<byte[]>(new ConcurrentQueue<byte[]>());
        public Queue<byte[]> delayedMessagesQueue = new Queue<byte[]>();
        void CreateConsumers()
        {
            for (int i = 0; i < maxConsumers; i++)
            {
                Task.Factory.StartNew(() => Consumer(),TaskCreationOptions.LongRunning);
            }
        }
        private void Consumer()
        {
            foreach (var item in inputQueue.GetConsumingEnumerable())
            {
                Thread.Sleep(latency);  
                delayedMessagesQueue.Enqueue(item);
            }
        }
    }
