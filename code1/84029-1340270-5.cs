    public class Parameter{
        public string Key { get; private set; }
        public object Value { get; protected internal set; }
        public ParameterDirection Direction { get; protected internal set; }
        public Parameter(string key, object value) : this(key, value, ParameterDirection.Input) { }
        public Parameter(string key, object value, ParameterDirection direction){
            Key = key;
            Value = value;
            Direction = direction;
        }
    }
    public class Parameters : List<Parameter>{
        public Parameters() { }
        public Parameters(object o){
            Populate(o);
        }
        public void Add(string key, object value){
            if (ContainsKey(key))
                throw new Exception("Parameter with the specified key already exists.");
            Add(new Parameter(key, value));
        }
        public void Add(string key, object value, ParameterDirection direction){
            if (ContainsKey(key))
                throw new Exception("Parameter with the specified key already exists.");
            Add(new Parameter(key, value, direction));
        }
        public bool ContainsKey(string key){
            return (Find(p => p.Key == key) != null);
        }
        protected internal int GetIndex(string key){
            int? index = null;
            for (int i = 0; i < Count; i++){
                if (this[i].Key == key){
                    index = i;
                    break;
                }
            }
            if (index == null)
                throw new IndexOutOfRangeException("Parameter with the specified key does not exist.");
            return (int)index;
        }
        public object this[string key]{
            get { return this[GetIndex(key)].Value; }
            set { this[GetIndex(key)].Value = value; }
        }
        private void Populate<T>(T obj){
            foreach (KeyValuePair<string, object> pair in new ObjectProperties(obj, BindingFlags.Public | BindingFlags.Instance))
                Add(pair.Key, pair.Value);
        }
    }
