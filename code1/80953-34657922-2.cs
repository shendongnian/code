    public static int IndexOf<T>(this IEnumerable<T> list, T item)
    {
        return list.Select((x, index) => EqualityComparer<T>.Default.Equals(item, x)
                                         ? index
                                         : -1)
                   .FirstOr(x => x != -1, -1);
    }
