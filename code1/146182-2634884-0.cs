    public class BoundedPriorityQueue<T>
    {
        private object locker;
        private int maxSize;
        private int count;
        private LinkedList<T>[] Buckets;
        public BoundedPriorityQueue(int buckets, int maxSize)
        {
            this.locker = new object();
            this.maxSize = maxSize;
            this.count = 0;
            this.Buckets = new LinkedList<T>[buckets];
            for (int i = 0; i < Buckets.Length; i++)
            {
                this.Buckets[i] = new LinkedList<T>();
            }
        }
        public bool TryUnsafeEnqueue(T item, int priority)
        {
            if (priority < 0 || priority >= Buckets.Length)
                throw new IndexOutOfRangeException("priority");
            Buckets[priority].AddLast(item);
            count++;
            if (count > maxSize)
            {
                UnsafeDiscardLowestItem();
                Debug.Assert(count <= maxSize, "Collection Count should be less than or equal to MaxSize");
            }
            return true; // always succeeds
        }
        public bool TryUnsafeDequeue(out T res)
        {
            LinkedList<T> bucket = Buckets.FirstOrDefault(x => x.Count > 0);
            if (bucket != null)
            {
                res = bucket.First.Value;
                bucket.RemoveFirst();
                count--;
                return true; // found item, succeeds
            }
            res = default(T);
            return false; // didn't find an item, fail
        }
        private void UnsafeDiscardLowestItem()
        {
            LinkedList<T> bucket = Buckets.Reverse().FirstOrDefault(x => x.Count > 0);
            if (bucket != null)
            {
                bucket.RemoveLast();
                count--;
            }
        }
        public bool TryEnqueue(T item, int priority)
        {
            lock (locker)
            {
                return TryUnsafeEnqueue(item, priority);
            }
        }
        public bool TryDequeue(out T res)
        {
            lock (locker)
            {
                return TryUnsafeDequeue(out res);
            }
        }
        public int Count
        {
            get { lock (locker) { return count; } }
        }
        public int MaxSize
        {
            get { return maxSize; }
        }
        public object SyncRoot
        {
            get { return locker; }
        }
    }
