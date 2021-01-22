    public static string Flatten(this IEnumerable elems, string separator)
    {
        if (elems == null)
        {
            return null;
        }
        StringBuilder sb = new StringBuilder();
        foreach (object elem in elems)
        {
            if (sb.Length > 0)
            {
                sb.Append(separator);
            }
            sb.Append(elem);
        }
        return sb.ToString();
    }
