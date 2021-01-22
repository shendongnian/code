    public static String Join<T>(this IEnumerable<T> items, String delimiter) {
        if (items == null)
            throw new ArgumentNullException("items");
        if (delimiter == null)
            throw new ArgumentNullException("delimiter");
        var strings = items.Select(item => item.ToString()).ToList();
        if (strings.Count == 0)
            return string.Empty;
        int length = strings.Sum(str => str.Length) +
                     delimiter.Length * (strings.Count - 1);
        var result = new StringBuilder(length);
        bool first = true;
        foreach (string str in strings) {
            if (first)
                first = false;
            else
                result.Append(delimiter);
            result.Append(str);
        }
        return result.ToString();
    }
