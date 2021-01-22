    if (table != null)
    {
      foreach (DataColumn col in table.Columns)
      {
        dataGrid.Columns.Add(new DataGridTextColumn { Header = col.ColumnName, Binding = new System.Windows.Data.Binding(string.Format("[{0}]", col.ColumnName)) });
      }
	
      dataGrid.DataContext = table;
    }
