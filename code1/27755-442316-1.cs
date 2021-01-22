    public class Container<T> : MarshalByRefObject
    {
        private T _value;
        public T Value { get { return _value; } set { _value = value; } }
        public Container() { }
        public Container(T value) { Value = value; }
        public static implicit operator T(Container<T> container)
        {
            return container.Value;
        }
    }
