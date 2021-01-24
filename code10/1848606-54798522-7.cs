    public static class DataReaderExtensions
    {
        public static IEnumerable<T> SelectRows<T>(this IDataReader reader, Func<IDataRecord, T> select)
        {
            while (reader.Read())
            {
                yield return select(reader);
            }
        }
    }
    public static class EnumerableExtensions
    {
        // Adapted from the answer to "Split List into Sublists with LINQ" by casperOne
        // https://stackoverflow.com/questions/419019/split-list-into-sublists-with-linq/
        // https://stackoverflow.com/a/419058
        // https://stackoverflow.com/users/50776/casperone
        public static IEnumerable<List<T>> ChunkBy<T>(this IEnumerable<T> enumerable, Func<List<T>, T, bool> shouldAdd)
        {
            if (enumerable == null || shouldAdd == null)
                throw new ArgumentNullException();
            return enumerable.ChunkByIterator(shouldAdd);
        }
        static IEnumerable<List<T>> ChunkByIterator<T>(this IEnumerable<T> enumerable, Func<List<T>, T, bool> shouldAdd)
        {
            List<T> list = new List<T>();
            foreach (var item in enumerable)
            {
                if (list.Count > 0 && !shouldAdd(list, item))
                {
                    yield return list;
                    list = new List<T>();
                }
                list.Add(item);
            }
            if (list.Count != 0)
            {
                yield return list;
            }
        }
    }
