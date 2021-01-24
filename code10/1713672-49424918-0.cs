    public class SubClass1 {
        private IDictionary<string, IList<IList<object>>> _variable;
        
        public IList<IList<object>> GetData(string key) {
            return _variable[key];
        }
    }
