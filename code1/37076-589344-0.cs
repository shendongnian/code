    public static string Join(this IEnumerable<string> source, string separator)
    {
        return String.Join(separator, source.ToArray());
    }
    public static string ToCsv<TRow>(this IEnumerable<TRow> rows, Func<double, string> valueToString)
        where TRow : IEnumerable<double>
    {
        return rows
            .Select(row => row.Select(valueToString).Join(", "))
            .Join(Environment.NewLine);
    }
