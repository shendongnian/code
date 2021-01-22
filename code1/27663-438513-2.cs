    static class LinqExtensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int parts)
        {
            int i = 0;
            var splits = from name in list
                         group name by i++ % parts into part
                         select part.AsEnumerable();
            return splits;
        }
    }
