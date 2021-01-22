    public static string Aggregate(this IEnumerable<string> l, Func<string, string, string> f) {
        StringBuilder sb = new StringBuilder();
        foreach (string item in l)
            sb.Append(item);
        return sb.ToString();
    }
