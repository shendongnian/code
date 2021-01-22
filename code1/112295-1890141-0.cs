    public static string JoinStrings<T>(
        this IEnumerable<T> collection, string separator)
    {
        var stringValues = collection.Select(item =>
            (item == null ? string.Empty : item.ToString()));
        return string.Join(separator, stringValues.ToArray());
    }
