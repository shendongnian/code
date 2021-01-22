    if (table != null) // table is a DataTable
    {
      foreach (DataColumn col in table.Columns)
      {
        dataGrid.Columns.Add(
          new DataGridTextColumn
          {
            Header = col.ColumnName,
            Binding = new Binding(string.Format("[{0}]", col.ColumnName))
          });
      }
 
      dataGrid.DataContext = table;
    }
