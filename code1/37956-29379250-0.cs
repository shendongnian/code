    public interface IMath<T>
    {
        T Add(T value1, T value2);
    }
    public class Math<T> : IMath<T>
    {
        public static readonly IMath<T> P = Math.P as IMath<T> ?? new Math<T>();
        //default implementation
        T IMath<T>.Add(T value1, T value2)
        {
            throw new NotSupportedException();    
        }
    }
    class Math : IMath<int>, IMath<double>
    {
        public static Math P = new Math();
        //specialized for int
        int IMath<int>.Add(int value1, int value2)
        {
            return value1 + value2;
        }
        //specialized for double
        double IMath<double>.Add(double value1, double value2)
        {
            return value1 + value2;
        }
    }
