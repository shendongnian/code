    public class EnumerableDisposer<T> : IDisposable 
        where T : IDisposable
    {
         public EnumerableDisposer(IEnumerable<T> enumerable)
         { 
            // ...
 
