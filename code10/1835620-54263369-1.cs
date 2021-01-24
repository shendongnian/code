    public class FixedSizeConcurrentQueue<T> : ConcurrentQueue<T>
    {
        private readonly object _sync = new object();
        private readonly int _maxSize;
    
        public int MaxSize 
        { 
            get 
            {
                lock (_sync)
                {
                    return _maxSize;
                }
            }
        }
    
        public FixedSizeConcurrentQueue(int maxSize)
        {
            _maxSize = maxSize;
        }
    
        public new void Enqueue(T obj)
        {
            base.Enqueue(obj);
    
            while (base.Count > MaxSize)
            {
                T outObj;
                base.TryDequeue(out outObj);
            }
        }
    
        public T GetElementAt(int index)
        {
            return base.ElementAtOrDefault(index);;
        }
    }
