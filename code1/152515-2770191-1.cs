    public MyClass CachedInstance
    {
        get { return _cachedInstance.Value; }
    }
    private static readonly Cached<MyClass> _cachedInstance = new Cached<MyClass>(() => new MyClass(), TimeSpan.FromMinutes(15));
    public sealed class Cached<T>
    {
        private readonly Func<T> _createValue;
        private readonly TimeSpan _cacheFor;
        private DateTime _createdAt;
        private T _value;
    
    
        public T Value
        {
            get
            {
                if (_createdAt == DateTime.MinValue || DateTime.Now - _createdAt > _cacheFor)
                {
                    lock (this)
                    {
                        if (_createdAt == DateTime.MinValue || DateTime.Now - _createdAt > _cacheFor)
                        {
                            _value = _createValue();
                            _createdAt = DateTime.Now;
                        }
                    }
                }
                return _value;
            }
        }
    
    
        public Cached(Func<T> createValue, TimeSpan cacheFor)
        {
            if (createValue == null)
            {
                throw new ArgumentNullException("createValue");
            }
            _createValue = createValue;
            _cacheFor = cacheFor;
        }
    }
