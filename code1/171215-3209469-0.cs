    public interface IPerson<out T>
    {
      T Value { get; }
    }
    public class Person<T> : IPerson<T>
    {
      public T Value { get; set; }
    }
    public static class PersonExt
    {
      public static void Process<TResult>(this IPerson<IEnumerable<TResult>> p)
      {
        // Do something with .Any(). 
        Console.WriteLine(p.Value.Any());
      }
    }
