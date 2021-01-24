    public class NewNumberType<T>
    {
        public NewNumberType(T v)
        {
            Value = v;
        }
        public NewNumberType()
        {
        }
        public T Value { get; set; }
        public static implicit operator NewNumberType<T>(T v)
        {
            return new NewNumberType<T>(v);
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
