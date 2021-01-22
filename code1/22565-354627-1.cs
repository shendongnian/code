    public static string Aggregate(this IEnumerable<string> l, Func<string, string, string> f) {
        StringBuilder sb = new StringBuilder();
        foreach (string item in l)
            sb.Append(", ").Append(item);
        return sb.Remove(0,2).ToString();
    }
