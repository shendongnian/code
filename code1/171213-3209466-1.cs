    public interface IPerson<out T>
    {
        T Value { get; }
    }
    public class Person<T>
        : IPerson<T>
    {
        public T Value { get; set; }
    }
