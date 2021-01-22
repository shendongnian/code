    public static string Implode(this IEnumerable<string> sequence,
        string separator)
    {
        var sb = new StringBuilder();
        foreach (string s in sequence)
        {
            sb.Append(s);
            sb.Append(separator);
        }
        if (separator != null && sb.Length > 0)
            sb.Length -= separator.Length; //remove the last separator
        return sb.ToString();
    }
