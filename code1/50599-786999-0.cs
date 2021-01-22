    public class LazyInit<T>
        where T : class
    {
        private readonly Func<T> _creationMethod;
        private readonly object syncRoot;
        private T _instance;
        [DebuggerHidden]
        private LazyInit()
        {
            syncRoot = new object();
        }
        [DebuggerHidden]
        public LazyInit(Func<T> creationMethod)
            : this()
        {
            _creationMethod = creationMethod;
        }
        public T Instance
        {
            [DebuggerHidden]
            get
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                        _instance = _creationMethod();
                    return _instance;
                }
            }
        }
        public static LazyInit<T> Create<U>() where U : class, T, new()
        {
            return new LazyInit<T>(() => new U());
        }
        [DebuggerHidden]
        public static implicit operator LazyInit<T>(Func<T> function)
        {
            return new LazyInit<T>(function);
        }
    }
