    class Key {}
    
    class Value {}
    
    class MySpecificStorage
    {
        public void AddSomeEntry(Key key, Value value)
        {
            dictionary[key] = value;
            values.Add(value);
        }
        public Value FindValueByKey(Key key)
        {
            //very simple
            return dictionary[key];
        }
        public IEnumerable<Value> GetSomeRange()
        {
            //use LINQ or something else
            //to fetch many structs, say 1% or less of all items, by another field.
            //You can even use different Dictionaries for that
            return ...;
        }
    
        private Dictionary<Key, Value> dictionary = new Dictionary<Key, Value>();
        private List<Value> values = new List<Value>(); //or List<KeyValuePair<Key, Value>> values;
        
    }
