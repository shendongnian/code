    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Trim<T>( this IEnumerable<T> collection, Func<T, bool> trimCondition )
        {
              return collection.SkipWhile( trimCondition ).Reverse().SkipWhile( trimCondition ).Reverse();
        }
    }
