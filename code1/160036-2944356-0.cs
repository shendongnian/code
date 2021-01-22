    class WeirdDictionary : IDictionary<Type, IEnumerable>
    {
        private readonly Dictionary<Type, IEnumerable> _data =
            new Dictionary<Type, IEnumerable>();
        public void Add<T>(IEnumerable<T> value)
        {
            _data.Add(typeof(T), value);
        }
        public bool TryGet<T>(out IEnumerable<T> value)
        {
            IEnumerable enumerable;
            if (_data.TryGetValue(typeof(T), out enumerable)
            {
                value = (IEnumerable<T>)enumerable;
                return true;
            }
            value = null;
            return false;
        }
        // use explicit implementation to discourage use of this method since
        // the manual type checking is much slower that the generic version above
        void IDictionary<Type, IEnumerable>.Add(Type key, IEnumerable value)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            if (value != null && !typeof(IEnumerable<>).MakeGenericType(key).IsAssignableFrom(value.GetType()))
                throw new ArgumentException(string.Format("'value' does not implement IEnumerable<{0}>", key));
            _data.Add(key, value);
        }
    }
