    /// <summary>
    /// SharedRef class, which implements reference counted IDisposable ownership.
    /// See also the static helper class for an easier construction syntax.
    /// </summary>
    public class SharedRef<T> : IDisposable
        where T:class,IDisposable
    {
        private SharedRefCounter<T> _t;
        /// <summary>
        /// Create a SharedRef directly from an object. Only use this once per object.
        /// After that, create SharedRefs from previous SharedRefs.
        /// </summary>
        /// <param name="t"></param>
        public SharedRef(T t)
        {
            _t = new SharedRefCounter<T>(t);
            _t.Retain();
        }
        /// <summary>
        /// Create a SharedRef from a previous SharedRef, incrementing the reference count.
        /// </summary>
        /// <param name="o"></param>
        public SharedRef(SharedRef<T> o)
        {
            o._t.Retain();
            _t = o._t;
        }
        public static SharedRef<T> Create(T t)
        {
            return new SharedRef<T>(t);
        }
        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                if (_t != null)
                {
                    _t.Release();
                    _t = null;
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
        }
        public T Get()
        {
            return _t.Get();
        }
    }
    /// <summary>
    /// Static helper class for easier construction syntax.
    /// </summary>
    public static class SharedRef
    {
        /// <summary>
        /// Create a SharedRef directly from an object. Only use this once per object.
        /// After that, create SharedRefs from previous SharedRefs.
        /// </summary>
        /// <param name="t"></param>
        public static SharedRef<T> Create<T>(T t) where T : class,IDisposable
        {
            return new SharedRef<T>(t);
        }
        /// <summary>
        /// Create a SharedRef from a previous SharedRef, incrementing the reference count.
        /// </summary>
        /// <param name="o"></param>
        public static SharedRef<T> Create<T>(SharedRef<T> o) where T : class,IDisposable
        {
            return new SharedRef<T>(o);
        }
    }
    /// <summary>
    /// Class which holds the reference count for a shared object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class SharedRefCounter<T> where T : class,IDisposable
    {
        private int _count;
        private readonly T _t;
        public T Get()
        {
            return _t;
        }
        public SharedRefCounter(T t)
        {
            _count = 0;
            _t = t;
        }
        /// <summary>
        /// Decrement the reference count, Dispose target if reaches 0
        /// </summary>
        public void Release()
        {
            lock (_t)
            {
                if (--_count == 0)
                {
                    _t.Dispose();
                }
            }
        }
        /// <summary>
        /// Increment the reference count
        /// </summary>
        public void Retain()
        {
            lock (_t)
            {
                ++_count;
            }
        }
    }
