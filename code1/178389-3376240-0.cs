    public class Sample
    {
        private IDictionary<string, string> _values = new Dictionary<string, string>();
    
        protected virtual IDictionary<string, string> GetDictionary()
        {
            return this._values;
        }
    
        public void AddValue(string key, string value)
        {
            GetDictionary().Add(key, value);
        }
    }
