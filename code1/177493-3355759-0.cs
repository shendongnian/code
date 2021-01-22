    public sealed class Type<T>
    {
        public Type(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            if (!typeof(T).IsAssignableFrom(type))
                throw new ArgumentException(string.Format("The specified type must be assignable to '{0}'.", typeof(T).FullName));
            this.Value = type;
        }
        public Type Value
        {
            get;
            private set;
        }
    }
