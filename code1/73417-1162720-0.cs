    interface ILeftistHeap<T> : IEnumerable<T>
    {
        Func<T, T, int> Comparer { get; }
        int Height { get; }
        T Item { get; }
        ILeftistHeap<T> Left { get; }
        ILeftistHeap<T> Right { get; }
        ILeftistHeap<T> Delete();
        ILeftistHeap<T> Add(T item);
        bool IsEmpty { get; }
    }
    sealed class LeftistHeap<T> : ILeftistHeap<T>
    {
        private static IEnumerator<T> CreateEnumerator(ILeftistHeap<T> heap)
        {
            while (!heap.IsEmpty)
            {
                yield return heap.Item;
                heap = heap.Delete();
            }
        }
        private static ILeftistHeap<T> Balance(T item, Func<T, T, int> comparer, ILeftistHeap<T> a, ILeftistHeap<T> b)
        {
            if (a.Height >= b.Height) { return new LeftistHeap<T>(comparer, b.Height + 1, item, a, b);  }
            else { return new LeftistHeap<T>(comparer, a.Height + 1, item, b, a); }
        }
        public static ILeftistHeap<T> Merge(ILeftistHeap<T> x, ILeftistHeap<T> y)
        {
            if (x.IsEmpty) { return y; }
            else if (y.IsEmpty) { return x; }
            else
            {
                Func<T, T, int> comparer = x.Comparer;
                if (comparer(x.Item, y.Item) <= 0) { return Balance(x.Item, comparer, x.Left, Merge(x.Right, y)); }
                else { return Balance(y.Item, comparer, y.Left, Merge(x, y.Right)); }
            }
        }
        public static ILeftistHeap<T> Make(Func<T, T, int> comparer) { return EmptyHeap<T>.Make(comparer); }
        public static ILeftistHeap<T> Make(Func<T, T, int> comparer, T item)
        {
            EmptyHeap<T> empty = EmptyHeap<T>.Make(comparer);
            return new LeftistHeap<T>(comparer, 1, item, empty, empty);
        }
        public Func<T, T, int> Comparer { get; private set; }
        public int Height { get; private set; }
        public T Item { get; private set; }
        public ILeftistHeap<T> Left { get; private set; }
        public ILeftistHeap<T> Right { get; private set; }
        public ILeftistHeap<T> Add(T item) { return Merge(this, Make(this.Comparer).Add(item)); }
        public ILeftistHeap<T> Delete() { return Merge(this.Left, this.Right); }
        public bool IsEmpty { get { return false; } }
        protected LeftistHeap(Func<T, T, int> comparer, int height, T item, ILeftistHeap<T> left, ILeftistHeap<T> right)
        {
            this.Comparer = comparer;
            this.Height = height;
            this.Item = item;
            this.Left = left;
            this.Right = right;
        }
        public IEnumerator<T> GetEnumerator() { return LeftistHeap<T>.CreateEnumerator(this); }
        IEnumerator IEnumerable.GetEnumerator() { return LeftistHeap<T>.CreateEnumerator(this); }
    }
    sealed class EmptyHeap<T> : ILeftistHeap<T>
    {
        private static IEnumerator<T> CreateEnumerator() { yield break; }
        public static EmptyHeap<T> Make(Func<T, T, int> comparer) { return new EmptyHeap<T>(comparer); }
        private EmptyHeap(Func<T, T, int> comparer) { this.Comparer = comparer; }
        public Func<T, T, int> Comparer { get; protected set; }
        public T Item { get { throw new Exception("Empty heap"); } }
        public int Height { get { return 0; } }
        public ILeftistHeap<T> Left { get { throw new Exception("Empty heap"); } }
        public ILeftistHeap<T> Right { get { throw new Exception("Empty heap"); } }
        public ILeftistHeap<T> Add(T item) { return LeftistHeap<T>.Make(this.Comparer, item); }
        public ILeftistHeap<T> Delete() { throw new Exception("Empty Heap"); }
        public bool IsEmpty { get { return true; } }
        public IEnumerator<T> GetEnumerator() { return EmptyHeap<T>.CreateEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return EmptyHeap<T>.CreateEnumerator(); }
    }
