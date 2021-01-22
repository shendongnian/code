    myTable.Delete("col1 > 5");
    public static DataTable Delete(this DataTable table, string filter)
    {
        table.Select(filter).Delete();
        return table;
    }
    public static void Delete(this IEnumerable<DataRow> rows)
    {
        foreach (var row in rows)
            row.Delete();
    }
