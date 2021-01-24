    public class BlockingQueue<T>
    {
        // In order to get rid of Lock object
        // Any thread should be able to add items to the queue
        private readonly ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();
        
        // Only one thread is able to consume from queue
        // You can fine tune this to your interest
        private readonly SemaphoreSlim _slim = new SemaphoreSlim(1,1);
        
        public void Add(T item) {
            _queue.Enqueue(item);
        }
        public bool TryTake(out T item, TimeSpan timeout) {
            if (_slim.Wait(timeout)){
                return _queue.TryDequeue(out item);
            }
            item = default(T);
            return false;
        }
    }
    
