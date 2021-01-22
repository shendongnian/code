    public class EnumerableDifferences<T>
    {
        public IEnumerable<T> Added { get; }
        public IEnumerable<T> Removed { get; }
        public EnumerableDifferences(IEnumerable<T> added, IEnumerable<T> removed)
        {
            Added = added;
            Removed = removed;
        }
    }
    public static class EnumerableExtensions
    {
        public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
        {
            return new HashSet<TSource>(source, comparer);
        }
        public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> keyComparer = null)
        {
            return first
                .ExceptBy(keySelector, second.Select(keySelector), keyComparer);
        }
        public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEnumerable<TKey> keys, IEqualityComparer<TKey> keyComparer = null)
        {
            var secondKeys = keys.ToHashSet(keyComparer);
            foreach (var firstItem in source)
            {
                var firstItemKey = keySelector(firstItem);
                if (!secondKeys.Contains(firstItemKey))
                {
                    yield return firstItem;
                }
            }
        }
        public static EnumerableDifferences<TSource> DifferencesBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> keyComparer = null)
        {
            keyComparer = keyComparer ?? EqualityComparer<TKey>.Default;
            var removed = first.ExceptBy(second, keySelector, keyComparer);
            var added = second.ExceptBy(first, keySelector, keyComparer);
            var result = new EnumerableDifferences<TSource>(added, removed);
            return result;
        }
        public static EnumerableDifferences<TSource> Differences<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer = null)
        {
            return first
                .DifferencesBy(second, x => x, comparer);
        }
    }
    public static class Program
    {
        public static void Main(params string[] args)
        {
            var l1 = new[] { 'a', 'b', 'c' };
            var l2 = new[] { 'a', 'd', 'c' };
            var result = l1.Differences(l2);
            Console.ReadKey();
        }
    }
