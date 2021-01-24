    public static class ExtensionMethods
    {
        public static IEnumerable<SpecialGroup<TKey>> GroupAccordingToSuccessiveItems<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            int index = 0;
            int count = 0;
            TKey latestKey = default(TKey);
            foreach (var item in source)
            {
                TKey key = keySelector(item);
                if (index != 0 && !object.Equals(key, latestKey))
                {
                    yield return new SpecialGroup<TKey>
                    {
                        Index = index - count,
                        Obj = latestKey,
                        Count = count
                    };
                    count = 0;
                }
                latestKey = key;
                count++;
                index++;
            }
            yield return new SpecialGroup<TKey>
            {
                Index = index - count,
                Obj = latestKey,
                Count = count
            };
        }
    }
    public class SpecialGroup<T>
    {
        public int Index { get; set; }
        public T Obj { get; set; }
        public int Count { get; set; }
    }
