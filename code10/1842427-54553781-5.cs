    public class Number
    {
        public int Value { get; set; }
        public Number(int value)
        {
            Value = value;
        }
    }
    public interface IAdder<T>
    {
        T Add(T x, T y);
    }
    public class NumberAdder : IAdder<Number>
    {
        public Number Add(Number x, Number y)
        {
            return new Number(x.Value + y.Value);
        }
    }
    T LongAlgorithm<T>(T x, IAdder<T> adder, Other parameters)
    {
       ... // Lots of code that may contain x
       T z = adder.Add(x, y);
       ... // Code Using z
 
       return z;
    }
