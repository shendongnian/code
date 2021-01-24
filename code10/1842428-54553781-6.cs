    public interface IAddable<T>
    {
        T Add(T x, T y);
    }
    public class Number : IAddable<Number>
    {
        public int Value { get; set; }
        public Number(int value)
        {
            Value = value;
        }
        public Number Add(Number other)
        {
            return new Number(Value + other.Value);
        }
    }
