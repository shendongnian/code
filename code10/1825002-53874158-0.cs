     public class EventArgs<T> : EventArgs
    {
        private T eventData;
        public EventArgs(T eventData)
        {
            this.eventData = eventData;
        }
        public T EventData
        {
            get { return eventData; }
        }
    }
    public class ObservableQueue<T>
    {
        public event EventHandler<EventArgs<T>> EnQueued;
        public event EventHandler<EventArgs<T>> DeQueued;
        public int Count { get { return queue.Count; } }
        private readonly Queue<T> queue = new Queue<T>();
        protected virtual void OnEnqueued(T item)
        {
            if (EnQueued != null)
                EnQueued(this, new EventArgs<T>(item));
        }
        protected virtual void OnDequeued(T item)
        {
            if (DeQueued != null)
                DeQueued(this, new EventArgs<T>(item));
        }
        public virtual void Enqueue(T item)
        {
            queue.Enqueue(item);
            OnEnqueued(item);
        }
        public virtual T Dequeue()
        {
            var item = queue.Dequeue();
            OnDequeued(item);
            return item;
        }
    }
