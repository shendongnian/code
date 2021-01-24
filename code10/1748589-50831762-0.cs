    class TestCollector<T> : ICollector<T>
    {
        public List<T> Collector => new List<T>();
        public void Add(T item)
        {
            Collector.Add(item);
        }
    }
