    public static String AppendAll(this IEnumerable<String> collection, String seperator)
    {
        using (var enumerator = collection.GetEnumerator())
        {
            if (!enumerator.MoveNext())
            {
                return String.Empty;
            }
            var builder = new StringBuilder().Append(enumerator.Current);
            while (enumerator.MoveNext())
            {
                builder.Append(seperator).Append(enumerator.Current);
            }
            return builder.ToString();
        }
    }
