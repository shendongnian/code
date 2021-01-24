    // pool of single object type, uses new for instantiation
    public class ObjectPool<T> where T : new()
    {
        // this will hold all the instances, notice that it's up to caller to make sure
        // the pool size is big enough not to reuse an object that's still in use
        private readonly T[] _pool = new T[_maxObjects];
        private int _current = 0;
        public ObjectPool()
        {
            // performs initialization, one may consider doing lazy initialization afterwards
            for (int i = 0; i < _maxObjects; ++i)
                _pool[i] = new T();
        }
        private const int _maxObjects = 100;  // Set this to whatever
        public T Get()
        {
            return _pool[_current++ % _maxObjects];
        }
    }
    // pool of generic pools
    public class PoolPool
    {
        // this holds a reference to pools of known (previously used) object pools
        // I'm dissatisfied with an use of object here, but that's a way around the generics :/
        private readonly Dictionary<Type, object> _pool = new Dictionary<Type, object>();
        public T Get<T>() where T : new()
        {
            // is the pool already instantiated?
            if (_pool.TryGetValue(typeof(T), out var o))
            {
                // if yes, reuse it (we know o should be of type ObjectPool<T>,
                // where T matches the current generic argument
                return ((ObjectPool<T>)o).Get();
            }
            // First time we see T, create new pool and store it in lookup dictionary
            // for later use
            ObjectPool<T> pool = new ObjectPool<T>();
            _pool.Add(typeof(T), pool);
            return pool.Get();
        }
    }
