    using System.Collections.Generic;
    using System.Linq;
    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> GroupsOf<T>(this IEnumerable<T> enumerable, int size)
        {
            return enumerable.Select((v, i) => new {v, i}).GroupBy(x => x.i/size, x => x.v);
        }
    }
