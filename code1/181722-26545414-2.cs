    public static IEnumerable<T> TakeLast<T>(IList<T> source, int takeCount)
    {
        if (source == null) { throw new ArgumentNullException("source"); }
        if (takeCount < 0) { throw new ArgumentOutOfRangeException("takeCount", "must not be negative"); }
        if (takeCount == 0) { yield break; }
        if (source.Count > takeCount)
        {
            for (int z = source.Count - 1; takeCount > 0; z--)
            {
                takeCount--;
                yield return source[z];
            }
        }
        else
        {
            for(int i = 0; i < source.Count; i++)
            {
                yield return source[i];
            }
        }
    }
