    public class ConcurrentAccessProvider<TObject>
    {
        private readonly Func<TObject> _getter;
        private readonly Action<TObject> _setter;
        private readonly object _lock = new object();
        public ConcurrentAccessProvider(Func<TObject> getter, Action<TObject> setter)
        {
            _getter = getter;
            _setter = setter;
        }
        public TObject Get()
        {
            lock (_lock)
            {
                return _getter();
            }
        }
        public void Set(TObject value)
        {
            lock (_lock)
            {
                _setter(value);
            }
        }
        public void Access(Action accessAction)
        {
            lock (_lock)
            {
                accessAction();
            }
        }
    }
