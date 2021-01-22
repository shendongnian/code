    public static string Implode<T>(this IEnumerable<T> sequence,
        string separator,
        Func<T, string> toString)
    {
        var sb = new StringBuilder();
        foreach (var obj in sequence)
        {
            sb.Append(toString(obj));
            sb.Append(separator);
        }
        if (separator != null && sb.Length > 0)
            sb.Length -= separator.Length; //remove the last separator
        return sb.ToString();
    }
