    public static string Stringify(this object o, string delimiter)
    {
        if (!(o is IEnumerable enumerable))
            return o.ToString();
        var sb = new StringBuilder();
        foreach (var i in enumerable)
        {
            if (sb.Length > 0)
                sb.Append(delimiter);
            sb.Append(i.ToString());
        }
        return sb.ToString();
    }
