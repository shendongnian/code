    public static string Join<T>(this IEnumerable<T> items, string separator)
    {
        // TODO: check for null arguments.
        StringBuilder builder = new StringBuilder();
        foreach(T t in items)
        {
            builder.Append(t.ToString()).Append(separator);
        }
        builder.Length -= separator.Length;
        return builder.ToString();
    }
