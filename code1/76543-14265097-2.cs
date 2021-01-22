    public static IEnumerable Append(this IEnumerable first, params object[] second)
    {
        return first.OfType<object>().Concat(second);
    }
    public static IEnumerable Append<T>(this IEnumerable<T> first, params T[] second)
    {
        return first.Concat(second);
    }   
    public static IEnumerable Prepend(this IEnumerable first, params object[] second)
    {
        return second.Concat(first);
    }
    public static IEnumerable Prepend<T>(
        this IEnumerable<T> first, params T[] second)
    {
        return second.Concat(first.OfType<object>());
    }
