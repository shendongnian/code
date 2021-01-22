    Public class HashSetHack<T> : //Whatever collection interfaces you need.
    {
        private readonly Dictionary<T, object> dict = new Dictionary<T, object>();
        //whatever code you need to wrap the interfaces using dict.Keys eg:
        public void Add(T value)
        {
          dict.add(value, null);
        }
    }
