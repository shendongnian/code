    public class ThreadLocal<T>
    {
        [ThreadStatic] private static Dictionary<object, T> _lookupTable;
        
        private Dictionary<object, T> LookupTable
        {
            get
            {
                if ( _lookupTable == null)
                    _lookupTable = new Dictionary<object, T>();
                return _lookupTable;
            }
        }
        private object key = new object(); //lazy hash key creation handles replacement
        private T originalValue;
        public ThreadLocal( T value )
        {
            originalValue = value;
        }
        ~ThreadLocal()
        {
            LookupTable.Remove(key);
        }
        public void Set( T value)
        {
            LookupTable[key] = value;
        }
        public T Get()
        {
            T returnValue = default(T);
            if (!LookupTable.TryGetValue(key, out returnValue))
                Set(originalValue);
            return returnValue;
        }
    }
