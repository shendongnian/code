    internal static class Utils
    {
        public static int IndexOf<T>(this IEnumerable<T> enumerable, T item) => enumerable.IndexOf(item, EqualityComparer<T>.Default);
        public static int IndexOf<T>(this IEnumerable<T> enumerable, T item, EqualityComparer<T> comparer)
        {
            int index = enumerable.TakeWhile(x => comparer.Equals(x, item)).Count();
            return index == enumerable.Count() ? -1 : index;
        }
    }
