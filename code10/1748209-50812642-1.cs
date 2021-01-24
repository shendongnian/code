    public static class OrderByTest
    {
        private static int Increment<TKey>(Dictionary<TKey, int> dict, TKey key)
        {
            int value;
            if (dict.TryGetValue(key, out value))
            {
                value++;
            }
            dict[key] = value;
            return value;
        }
        public static IEnumerable<TSource> OrderByPartition<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var dict = new Dictionary<TKey, int>();
            var res = source.Select(x => new { Value = x, Partition = Increment(dict, keySelector(x)) }).OrderBy(x => x.Partition).ThenBy(x => keySelector(x.Value));
            foreach (var value in res)
            {
                yield return value.Value;
            }
        }
    }
