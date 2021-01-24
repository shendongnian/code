    public class MyCollection
    {
        private readonly ConcurrentBag<(DateTime Timestamp, string Value)> _items;
        private readonly int _hoursLimit;
    
        public MyCollection(int hoursLimit)
        {
            _items = new ConcurrentBag<(DateTime, string)>();
            _hoursLimit = -1 * hoursLimit;
        }
    
        public void Add(string value)
        {
            var item = (DateTime.Now, value);
            _items.Add(item);
        }
    
        public IEnumerable<string> GetLast(int amount)
        {
            var lastTimestamp = DateTime.Now.AddHours(_hoursLimit);
    
            return _items.Where(item => item.Timestamp > lastTimestamp)
                         .Select(item => item.Value)
                         .Take(amount);
        }
    }
