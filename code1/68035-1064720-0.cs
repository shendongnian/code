    public class Tree<T>
    {
        private Dictionary<string, T> _store = new Dictionary<string, T>();
    
        private string GetKey(string[] index)
        {
            if (index == null || index.Length == 0) return string.Empty;
            return string.Join(".", index);
        }
    
        public T this[params string[] index]
        {
            get
            {
                var key = GetKey(index);
                if (!_store.ContainsKey(key))
                    return default(T);
                return _store[key];
            }
            set
            {
                var key = GetKey(index);
                if (_store.ContainsKey(key))
                    _store.Remove(key);
                if (value != null)
                    _store.Add(key, value);
            }
        }
    }
