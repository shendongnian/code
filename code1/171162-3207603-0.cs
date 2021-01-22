    public class Lazy<T>
    {
        private readonly Func<T> initializer;
        private bool isValueCreated;
        private T value;
        public Lazy(Func<T> initializer)
        {
            if (initializer == null)
                throw new ArgumentNullException("initializer");
            this.initializer = initializer;
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
