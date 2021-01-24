    public class FixedSizeConcurrentQueue<T> : ConcurrentQueue<T>
    {
        private readonly object _sync = new object();
    
        public int Size { get; }
    
        public FixedSizeConcurrentQueue(int size)
        {
            Size = size;
        }
    
        public new void Enqueue(T obj)
        {
            base.Enqueue(obj);
    
            lock (_sync)
            {
                while (base.Count > Size)
                {
                    T outObj;
                    base.TryDequeue(out outObj);
                }
            }
        }
    
        public T GetElementAt(int index)
        {
            return base.ElementAtOrDefault(index);;
        }
    }
