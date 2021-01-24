 C#
public static class FunctionalExtensions
{
    public static TResult Pipe<T, TResult>(this T value, Func<T, TResult> func) =>
        func(value);
}
And call it like this
 C#
public static string Foo(IBar bar) =>
    bar.LongCalculation()
       .Pipe(result => result.HasError
           ? throw new Exception()
           : result.ToString();
