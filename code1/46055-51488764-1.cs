    public struct NotNull<T> where T : class
    {
        private T valueField;
        public NotNull(T value)
        {
            this.valueField = value;
            this.CheckNotNull(value);
        }
        public T Value => this.valueField;
        public static implicit operator T(NotNull<T> t)
        {
            return t.Value;
        }
        public static implicit operator NotNull<T>(T t)
        {
            return new NotNull<T>(t);
        }
        public override bool Equals(object other)
        {
            return this.Value.Equals(other);
        }
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
        public override string ToString()
        {
            return this.Value.ToString();
        }
        private void CheckNotNull(T value)
        {
            if (value == null)
            {
                throw new InvalidOperationException($"Value cannot be null");
            }
        }
    }
