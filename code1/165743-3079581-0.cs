    public class ParameterizedProperty<TReturn, TIndexer>
    {
        private Dictionary<TIndexer, TReturn> storage = new Dictionary<TIndexer, TReturn>();
    
        public TReturn this[TIndexer index]
        {
            get
            {
                TReturn output;
    
                storage.TryGetValue(index, out output);
    
                return output;
            }
            set { storage[index] = value; }
        }
    }
