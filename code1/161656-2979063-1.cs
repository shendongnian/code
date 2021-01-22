    class HashTable
    {
        private List<KeyValuePair<int, List<KeyValuePair<string, object>>>> _table = 
            new List<KeyValuePair<int, List<KeyValuePair<string, object>>>>();
        private void Add(string key, object value)
        {
            var hashcode = key.GetHashCode();
            List<KeyValuePair<string, object>> l;
            if(!_table.TryGetKey(hashcode, out l))
            {
                l = new List<KeyValuePair<string, object>>();
                _table.Add(hashcode, l);
            }
            l.Add(key, value);
        }
        private object this[string key]
        {
            List<KeyValuePair<string, object>> l;
            object o;
            if(!(_table.TryGetKey(hashcode, out l) && !l.TryGetKey(key, out o)))
            {
                throw new ArgumentOutOfRangeException("key");
            }
            return o;
        }
    }
