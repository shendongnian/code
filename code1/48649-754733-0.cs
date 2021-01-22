    public class EventQueue<T> : Queue<T>
    {
        public delegate void OnQueueMadeEmptyDelegate();
        public event OnQueueMadeEmptyDelegate OnQueueMadeEmpty;
        public delegate void OnQueueMadeNonEmptyDelegate();
        public event OnQueueMadeNonEmptyDelegate OnQueueMadeNonEmpty;
        public new void Enqueue(T item)
        {
            var oldCount = Count;
            base.Enqueue(item);
            if (OnQueueMadeNonEmpty != null &&
                oldCount == 0 && Count > 0)
                // FIRE EVENT
                OnQueueMadeNonEmpty();
        }
        public new T Dequeue()
        {
            var oldCount = Count;
            var item = base.Dequeue();
            if (OnQueueMadeEmpty != null &&
                oldCount > 0 && Count == 0)
            {
                // FIRE EVENT
                OnQueueMadeEmpty();
            }
            return item;
        }
        public new void Clear()
        {
            base.Clear();
            if (OnQueueMadeEmpty != null)
            {
                // FIRE EVENT
                OnQueueMadeEmpty();
            }
        }
    }
