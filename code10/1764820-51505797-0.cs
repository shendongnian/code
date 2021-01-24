    private static DataTable CreateDataTable(IEnumerable<long> ids) {
        DataTable table = new DataTable();
        table.Columns.Add("ID", typeof(long));
        foreach (long id in ids) {
            table.Rows.Add(id);
        }
        return table;
    }
