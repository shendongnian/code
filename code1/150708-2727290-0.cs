    public class Wrapper<T>
    {
        public T Value { get; private set; }
        public Wrapper(T value)
        {
            Value = value;
        }
    }
