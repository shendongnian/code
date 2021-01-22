    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Skip( this IEnumerable<T> source, Func<int> toSkip )
        {
             return source.Skip( toSkip() );
        }
    }
    FibonacciWithLinq.Skip( () => { return 5; } );
