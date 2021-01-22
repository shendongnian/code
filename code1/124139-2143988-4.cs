    class IndexedList<T> : IEnumerable<T> {
        List<T> _list;
        Dictionary<string, Dictionary<object, List<T>>> _dictionary;
        Dictionary<string, Func<T, object>> _propertyDictionary;
        public IndexedList(IEnumerable<string> propertyNames) : this(propertyNames, new List<T>()) { }
        public IndexedList(IEnumerable<string> propertyNames, IEnumerable<T> source) {
            _list = new List<T>();
            _dictionary = new Dictionary<string, Dictionary<object, List<T>>>();
            _propertyDictionary = BuildPropertyDictionary(propertyNames);
            foreach (var item in source) {
                Add(item);
            }
        }
        static Dictionary<string, Func<T, object>> BuildPropertyDictionary(IEnumerable<string> keys) {
            var propertyDictionary = new Dictionary<string,Func<T,object>>();
            foreach (string key in keys) {
                ParameterExpression parameter = Expression.Parameter(typeof(T), "parameter");
                Expression property = Expression.Property(parameter, key);
                Expression converted = Expression.Convert(property, typeof(object));
                Func<T, object> func = Expression.Lambda<Func<T, object>>(converted, parameter).Compile();
                propertyDictionary.Add(key, func);
            }
            return propertyDictionary;
        }
        public int IndexOf(T item) {
            return _list.IndexOf(item);
        }
        public void Add(T item) {
            Insert(_list.Count, item);
        }
        public void Insert(int index, T item) {
            _list.Insert(index, item);
            foreach (var kvp in _propertyDictionary) {
                object key = kvp.Value(item);
                Dictionary<object, List<T>> propertyIndex;
                if (!_dictionary.TryGetValue(kvp.Key, out propertyIndex)) {
                    propertyIndex = new Dictionary<object, List<T>>();
                    _dictionary.Add(kvp.Key, propertyIndex);
                }
                List<T> list;
                if (!propertyIndex.TryGetValue(key, out list)) {
                    list = new List<T>();
                    propertyIndex.Add(key, list);
                }
                propertyIndex[key].Add(item);
            }
        }
        public IEnumerable<T> GetByIndex<TIndex>(string propertyName, TIndex index) {
            return _dictionary[propertyName][index];
        }
        public IEnumerator<T> GetEnumerator() {
            return _list.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
