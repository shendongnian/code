    public static IEnumerable<object[]> WhereEqual(
        this IEnumerable<object[]> source,
        Collection<string> columnNames,
        string column,
        object value)
    {
        int columnIndex = columnNames.IndexOf(column);
        if (columnIndex == -1)
        {
            throw new ArgumentException();
        }
        return source.Where(row => Object.Equals(row[columnIndex], value);
    }
