    DataColumnCollection columns = ds.Tables[0].Columns;
    foreach (DataColumn column in columns)
    {
        listBox1.Items.Add(column.ColumnName);
    }
