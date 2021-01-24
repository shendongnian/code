    var dt = new DataTable();
    foreach (DataTable t in ds.Tables)
    {
        foreach (DataColumn c in t.Columns)
        {
            dt.Columns.Add(c.ColumnName, c.DataType);
        }
    }
    foreach (DataRow r in ds.Tables[0].Rows)
    {
        var row = dt.NewRow();
        dt.Rows.Add(row);
    }
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        foreach (DataTable t in ds.Tables)
        {
            foreach (DataColumn c in t.Columns)
            {
                dt.Rows[i][c.ColumnName] = t.Rows[i][c.ColumnName];
            }
        }
    }
