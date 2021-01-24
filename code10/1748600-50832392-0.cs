    class TestCollector<T> : ICollector<T>
    {
        private List<T> Collector _collector = new List<T>();
        public List<T> Collector => _collector;
        public void Add(T item)
        {
            Collector.Add(item);
        }
    }
