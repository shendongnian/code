    public static DataTable AsDataTable(this IQueryable value, DataTable table)
    {
        var reader = value.GetEnumerator();
        while (reader.MoveNext())
        {
            var record = (Customer)reader.Current;
            table.Rows.Add(record.CustomerID, record.City);
        }
        return table;
    }
