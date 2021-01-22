    public static class Extension
    {
        private static IEnumerable<TList> Split<TList, T>(this TList value, int countOfEachPart) where TList : IEnumerable<T>
        {
            int cnt = value.Count() / countOfEachPart;
            List<IEnumerable<T>> result = new List<IEnumerable<T>>();
            for (int i = 0; i <= cnt; i++)
            {
                IEnumerable<T> newPart = value.Skip(i * countOfEachPart).Take(countOfEachPart).ToArray();
                if (newPart.Any())
                    result.Add(newPart);
                else
                    break;
            }
            return result.Cast<TList>();
        }
        public static IEnumerable<IDictionary<TKey, TValue>> Split<TKey, TValue>(this IDictionary<TKey, TValue> value, int countOfEachPart)
        {
            IEnumerable<Dictionary<TKey, TValue>> result = value.ToArray()
                                                                .Split(countOfEachPart)
                                                                .Select(p => p.ToDictionary(k => k.Key, v => v.Value));
            return result;
        }
        public static IEnumerable<IList<T>> Split<T>(this IList<T> value, int countOfEachPart)
        {
            return value.Split<IList<T>, T>(countOfEachPart);
        }
        public static IEnumerable<T[]> Split<T>(this T[] value, int countOfEachPart)
        {
            return value.Split<T[], T>(countOfEachPart);
        }
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> value, int countOfEachPart)
        {
            return value.Split<IEnumerable<T>, T>(countOfEachPart);
        }
    }
