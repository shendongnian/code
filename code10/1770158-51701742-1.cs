            public class ErrorProvider
            {
        private Dictionary<string, string> _errorDic = new Dictionary<string, string>();
        public void AddOrUpdateError(string key, string value)
        {
            _errorDic[key] = value;
            //_errorDic.TryAdd(key,value);
        }
        public string Error(string key)
        {
            string value = null;
            _errorDic.TryGetValue(key, out value);
            return value;
        }
        }
