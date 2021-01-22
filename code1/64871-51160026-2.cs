    DataTable table = new DataTable();
    table.Columns.Add("col1");
    table.Columns.Add("col2");
    table.Columns.Add("col3");
    foreach (var i in yourTablesource(db,list,etc))
    {
      table.Rows.Add(i.col1, i.col2, i.col2);
    }
    datagridview1.DataSource = table;
