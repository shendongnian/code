    public class SafeDictionary<TKey, TValue>: IDictionary<TKey, TValue>
    {
        private readonly object syncRoot = new object();
        private Dictionary<TKey, TValue> d = new Dictionary<TKey, TValue>();
        public void Add(TKey key, TValue value)
        {
            lock (syncRoot)
            {
                d.Add(key, value);
            }
            OnItemAdded(EventArgs.Empty);
        }
        public event EventHandler ItemAdded;
        protected virtual void OnItemAdded(EventArgs e)
        {
            EventHandler handler = ItemAdded;
            if (handler != null)
                handler(this, e);
        }
        // more IDictionary members...
    }
