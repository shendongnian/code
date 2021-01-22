    class HashTable<T>
    {
        private List<KeyValuePair<int, List<KeyValuePair<string, T>>>> _table = 
            new List<KeyValuePair<int, List<KeyValuePair<string, T>>>>();
        private void Set(string key, T value)
        {
            var hashcode = key.GetHashCode();
            List<KeyValuePair<string, T>> l;
            if(!_table.TryGetValue(hashcode, out l))
            {
                l = new List<KeyValuePair<string, T>>();
                _table.Add(hashcode, l);
            }
            T o;
            if(l.TryGetValue(key, out o))
            {
                if (o != value)
                    l.Single(x => x.Key == key).Value = o;
            }
            else
                l.Add(new KeyValuePair(key, value));
        }
        private T Get(string key)
        {
            List<KeyValuePair<string, T>> l;
            object o;
            if(!(_table.TryGetValue(hashcode, out l) && 
                !l.TryGetValue(key, out o)))
            {
                throw new ArgumentOutOfRangeException("key");
            }
            return o;
        }
    }
