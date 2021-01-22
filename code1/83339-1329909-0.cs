    public class MyDictionary
    {
        private Dictionary<string, string> values;
    
        public MyDictionary()
        {
            values = new Dictionary<string, string>();
        }
    
        public void Add(int index, string key, string value)
        {
            int hash = ((0xFFFF) & index) * (0xFFFF) + (0xFFFF) & key.GetHashCode();
            values.Add(hash, value);
        }
        public string Get(int index, string key)
        {
            int hash = ((0xFFFF) & index) * (0xFFFF) + (0xFFFF) & key.GetHashCode();
            return values[hash];
        }
    }
