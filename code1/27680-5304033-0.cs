    static class LinqExtensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int parts)
        {
                return list.Select((item, index) => new {index, item})
                           .GroupBy(x => x.index % parts)
                           .Select(x => x.Select(y => y.item));
        }
    }
