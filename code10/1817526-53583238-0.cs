    public static partial class EnumerableExtensions
    {
        public static bool IfNonEmpty<T>(this IEnumerable<T> source, Action<IEnumerable<T>> func)
        {
            if (source == null|| func == null)
                throw new ArgumentNullException();
            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    return false;
                func(CreateIEnumerable(enumerator));
                return true;
            }
        }
        static IEnumerable<T> CreateIEnumerable<T>(IEnumerator<T> usedEnumerator)
        {
            yield return usedEnumerator.Current;
            while (usedEnumerator.MoveNext())
            {
                yield return usedEnumerator.Current;
            }
        }
    }
