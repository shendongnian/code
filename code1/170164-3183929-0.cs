    public struct Nullable<T>
    {
        private readonly bool hasValue;
        public bool HasValue { get { return hasValue; } }
        private readonly T value;
        public T value
        {
            get
            {
                if (!hasValue)
                {
                    throw new InvalidOperationException();
                }
                return value;
            }
        }
        public Nullable(T value)
        {
            this.value = value;
            this.hasValue = true;
        }
        // Calling new Nullable<int>() or whatever will use the
        // implicit initialization which leaves value as default(T)
        // and hasValue as false.
    }
