    public static string Join<TItem,TSep>(
        this IEnumerable<TItem> enuml,
        TSep                    separator)
    {
        if (null == enuml) return string.Empty;
        var sb = new StringBuilder();
        
        var enumr = enuml.GetEnumerator();
        if (null != enumr && enumr.MoveNext())
        {
            sb.Append(enumr.Current);
            while (enumr.MoveNext())
            {
                sb.Append(separator).Append(enumr.Current);
            }
        }
        return sb.ToString();
    }
