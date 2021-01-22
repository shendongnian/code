    public class CachedValue<T>
    {
        private Func<T> initializer;
        private bool isValueCreated;
        private T value;
        public CachedValue(Func<T> initializer)
        {
            if (initializer == null)
                throw new ArgumentNullException("initializer");
            this.initializer = initializer;
        }
        public CachedValue(T value)
        {
            this.value = value;
            this.isValueCreated = true;
        }
        public static implicit operator T(CachedValue<T> lazy)
        {
            return (lazy != null) ? lazy.Value : default(T);
        }
        public static implicit operator CachedValue<T>(T value)
        {
            return new CachedValue<T>(value);
        }
        public bool IsValueCreated
        {
            get { return isValueCreated; }
        }
        public T Value
        {
            get
            {
                if (!isValueCreated)
                {
                    value = initializer();
                    isValueCreated = true;
                }
                return value;
            }
        }
    }
