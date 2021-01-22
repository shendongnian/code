    public static string Join<TItem,TSep>(this IEnumerable<TItem> enumerable, TSep separator)
    {
        var sb = new StringBuilder();
        if (enumerable.Any())
        {
            sb.Append(enumerable.First());
        }
        foreach (var t in enumerable.Skip(1))
        {
            sb.Append(separator).Append(t);
        }
        return sb.ToString();
    }
