    private void AddTwoDataTable()
    {
        DataTable dt1 = new DataTable();
        dt1.Columns.Add("ID1", typeof(int));
        dt1.Columns.Add("Value1", typeof(string));
        dt1.Columns.Add("Value2", typeof(string));
        DataTable dt2 = new DataTable();
        dt2.Columns.Add("ID2", typeof(int));
        dt2.Columns.Add("Value3", typeof(string));
        dt1.Rows.Add(new object[] { 1, "a", "ab"});
        dt1.Rows.Add(new object[] { 2, "b", "bc" });
        dt1.Rows.Add(new object[] { 3, "c", "cd" });
        dt1.Rows.Add(new object[] { 4, "d", "de" });
        dt2.Rows.Add(new object[] { 101, "x" });
        dt2.Rows.Add(new object[] { 102, "y" });
        dt2.Rows.Add(new object[] { 103, "y" });
        var newtable = MergetwoTables( dt1, dt2 );
        dataGridView1.DataSource = newtable;
    }
    public static DataTable MergetwoTables(DataTable dt1, DataTable dt2)
    {
        DataTable table = new DataTable("NewTable");
        table.Merge(dt1);
        table.Merge(dt2);
        int maxRows1 = dt1.Rows.Count;
        int maxColu1 = dt1.Columns.Count;
        int maxRows2 = dt2.Rows.Count;
        int maxColu2 = dt2.Columns.Count;
        // copy elements from new rows
        for (int r = maxRows1; r < maxRows1 + maxRows2; r++)
            for (int c = maxColu1; c < maxColu1 + maxColu2; c++)
                table.Rows[r - maxRows1][c] = table.Rows[r][c];
        //delete new rows
        for (int r = maxRows1 + maxRows2 - 1; r >= maxRows1; r--)
            table.Rows[r].Delete();
        return table;
    }
