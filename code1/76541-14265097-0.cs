    public static IEnumerable Concat(this IEnumerable first, params object[] second)
    {
        return first.Concat(second);
    }
    public static IEnumerable Concat<T>(this IEnumerable<T> first, params T[] second)
    {
        return first.Concat(second);
    }
