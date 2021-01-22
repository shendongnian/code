    // Type: System.Linq.Enumerable
    // Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
    // Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Core.dll
    public static class Enumerable
    {
        public static IEnumerable<TSource> Where<TSource>(
            this IEnumerable<TSource> source, 
            Func<TSource, bool> predicate)
        {
            return (IEnumerable<TSource>) 
                new Enumerable.WhereEnumerableIterator<TSource>(source, predicate);
        }
    }
