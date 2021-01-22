    public static IEnumerable<T> DistinctConcat<T>(IEnumerable<T> first, IEnumerable<T> second)
    {
        HashSet<T> returned = new HashSet<T>();
        foreach (T element in first)
        {
            if (returned.Add(element))
            {
                yield return element;
            }
        }
        foreach (T element in second)
        {
            if (returned.Add(element))
            {
                yield return element;
            }
        }
    }
