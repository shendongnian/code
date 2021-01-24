    class ObservableQueue<T> : Queue<T>, INotifyCollectionChanged
    {
        public ObservableQueue()
        {
        }
        public ObservableQueue(int capacity) : base(capacity)
        {
        }
        public ObservableQueue(IEnumerable<T> collection) : base(collection)
        {
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public new void Clear()
        {
            base.Clear();
            if(this.CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        public new void Enqueue(T item)
        {
            base.Enqueue(item);
            if (this.CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
        }
        public new T Dequeue()
        {
            T item = base.Dequeue();
            if (this.CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
            return item;
        }
    }
