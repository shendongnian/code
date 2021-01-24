 csharp
public static class FunctionalExtensions
{
    public static T Assign<T>(this T o, out T result) =>
        result = o;
}
And call it like this
 csharp
public static string Foo(IBar bar) =>
    bar.LongCalculation()
       .Assign(out var result)
       .HasError
           ? throw new Exception()
           : result.ToString();
