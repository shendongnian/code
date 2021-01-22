    public static string JoinStrings<T>(
        this IEnumerable<T> values, string separator)
    {
        var stringValues = values.Select(item =>
            (item == null ? string.Empty : item.ToString()));
        return string.Join(separator, stringValues.ToArray());
    }
