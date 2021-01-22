    Agent.SendMessage
    (
        new Message(MessageTypes.SomethingHappened) {{ "foo", 42 }, { "bar", 123 }}
    );
    // ...
    public class Message : IEnumerable
    {
        private Dictionary<string, object> _map = new Dictionary<string, object>();
        public Message(MessageTypes mt)
        {
            // ...
        }
        public void Add(string key, object value)
        {
            _map.Add(key, value);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_map).GetEnumerator();
            // or throw a NotImplementedException if you prefer
        }
    }
