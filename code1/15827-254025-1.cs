    public static string JoinStrings<string>(this IEnumerable<string> source, 
                                             string separator)
    {
        StringBuilder builder = new StringBuilder();
        bool first = true;
        foreach (T element in source)
        {
            if (first)
            {
                first = false;
            }
            else
            {
                builder.Append(separator);
            }
            builder.Append(element);
        }
        return builder.ToString();
    }
