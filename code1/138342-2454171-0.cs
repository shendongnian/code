    public static class ListExtensions
    {
        public static IEnumerable<T> Every<T>(this IList<T> list, int stepSize, int startIndex)
        {
            if (stepSize <= 0)
                throw new ArgumentException();
            for (int i = startIndex; i < list.Count; i += stepSize)
                yield return list[i];
        }
    }
