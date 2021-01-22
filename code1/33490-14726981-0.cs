     public class ProducerConsumerQueue<T> : BlockingCollection<T>
    {
        /// <summary>
        /// Initializes a new instance of the ProducerConsumerQueue, Use Add and TryAdd for Enqueue and TryEnqueue and Take and TryTake for Dequeue and TryDequeue functionality
        /// </summary>
        public ProducerConsumerQueue()  
            : base(new ConcurrentQueue<T>())
        {
        }
      /// <summary>
      /// Initializes a new instance of the ProducerConsumerQueue, Use Add and TryAdd for Enqueue and TryEnqueue and Take and TryTake for Dequeue and TryDequeue functionality
      /// </summary>
      /// <param name="maxSize"></param>
        public ProducerConsumerQueue(int maxSize)
            : base(new ConcurrentQueue<T>(), maxSize)
        {
        }
        
    }
