    private static string ToDelimitedStringImpl<TSource>
        (IEnumerable<TSource> source, string delimiter)
    {
        Debug.Assert(source != null);
        Debug.Assert(delimiter != null);
        var sb = new StringBuilder();
        foreach (var value in source)
        {
            if (sb.Length > 0) sb.Append(delimiter);
            sb.Append(value);
        }
        return sb.ToString();
    }
