    public static bool HasDuplicates<T>(this IEnumerable<T> subjects)
    {
        return HasDuplicates(subjects, EqualityComparer<T>.Default);
    }
    public static bool HasDuplicates<T>(this IEnumerable<T> subjects, IEqualityComparer<T> comparer)
    {
        HashSet<T> set = new HashSet<T>(comparer);
        foreach (T item in subjects)
        {
            if (!set.Add(item))
                return true;
        }
        return false;
    }
