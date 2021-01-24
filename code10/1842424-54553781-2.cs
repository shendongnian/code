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
        public Number Add(Number x, Number y)
        {
            return new Number(x.Value + y.Value);
        }
    }
