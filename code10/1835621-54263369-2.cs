    public class FixedSizeConcurrentQueue<T> : ConcurrentQueue<T>
    {
        public int MaxSize { get; }
    
        public FixedSizeConcurrentQueue(int maxSize)
        {
            MaxSize = maxSize;
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
