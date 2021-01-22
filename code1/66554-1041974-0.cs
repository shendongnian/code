    public static IEnumerable<DataRow> getRows(DataTable table)
    {
        foreach (DataRow row in table.Rows)
        {
            yield return row;
        }
    }
