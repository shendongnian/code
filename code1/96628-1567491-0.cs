    public static string ToStrings<T>(this IEnumerable<T> input)
    {
        var sb = new StringBuilder();
        sb.Append("[");
        if (input.Count() > 0)
        {
            sb.Append(input.First());
            foreach (var item in input.Skip(1))
            {
                sb.Append(", ");
                sb.Append(item);
            }
        }
        sb.Append("]");
        return sb.ToString();
    }
