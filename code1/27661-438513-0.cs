    static class LinqExtensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this List<T> list, int parts)
        {
            int i = 0;
            var splits = from name in list
                         group name by i++ % parts into piece
                         select (IEnumerable<T>)piece;
            return (IEnumerable<IEnumerable<T>>)splits;
        }
    }
