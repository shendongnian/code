    public static string ToCsv<T>(this IEnumerable<T> list, params Func<T, string>[] properties)
    {
        var columns = properties.Select(func => list.Select(func).ToList()).ToList();
        var stringBuilder = new StringBuilder();
        var rowsCount = columns.First().Count;
        for (var i = 0; i < rowsCount; i++)
        {
            var rowCells = columns.Select(column => column[i]);
            stringBuilder.AppendLine(string.Join(",", rowCells));
        }
        return stringBuilder.ToString();
    }
