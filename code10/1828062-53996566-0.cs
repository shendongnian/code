    private DataTable LoadProducts()
    {
        var dt = new DataTable();
        dt.Columns.Add("Name");
        dt.Columns.Add("CategoryId", typeof(int));
        dt.Rows.Add("P1", 1);
        dt.Rows.Add("P2", 1);
        dt.Rows.Add("P3", DBNull.Value);
        return dt;
    }
    private DataTable LoadCategories()
    {
        var dt = new DataTable();
        dt.Columns.Add("Id", typeof(int));
        dt.Columns.Add("Name");
        dt.Rows.Add(DBNull.Value, "No Category");
        dt.Rows.Add(1, "C1");
        dt.Rows.Add(2, "C2");
        dt.Rows.Add(2, "C3");
        return dt;
    }
