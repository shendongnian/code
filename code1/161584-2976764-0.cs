    public class ValueWrapper<T>
    {
        public T Value
        {
            get;
            private set;
        }
        public Type WrappedType
        {
            get { return typeof(T); }
        }
    }
    public MySpecialInt : ValueWrapper<int>
    {
        /* etc */
    }
