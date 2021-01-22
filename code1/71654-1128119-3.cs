    public static IEnumerable<T> ToEnumerable<T>(this DataTable table, Func<DataRow, T> TFactory) 
    {
        foreach (DataRow row in table.Rows)
        {
            yield return TFactory(row);
        }
    }
