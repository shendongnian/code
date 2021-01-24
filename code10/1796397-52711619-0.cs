    private class TestSession : ISession
    {
        private Dictionary<string, byte[]> _store
            = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        public string Id { get; set; }
        public bool IsAvailable { get; } = true;
        public IEnumerable<string> Keys { get { return _store.Keys; } }
        public void Clear()
        {
            _store.Clear();
        }
        public Task CommitAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
        public Task LoadAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
        public void Remove(string key)
        {
            _store.Remove(key);
        }
        public void Set(string key, byte[] value)
        {
            _store[key] = value;
        }
        public bool TryGetValue(string key, out byte[] value)
        {
            return _store.TryGetValue(key, out value);
        }
    }
    private class BlahSessionFeature : ISessionFeature
    {
        public ISession Session { get; set; }
    }
