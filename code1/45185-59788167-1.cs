      foreach (DataColumn col in dt.Columns)
      {
        TrkDataGrid.Columns.Add(
          new DataGridTextColumn
          {
            Header = col.ColumnName,
            Binding = new Binding(string.Format("[{0}]", col.ColumnName))
          });
      }
 
      TrkDataGrid.ItemsSource= dt.DefaultView;
  
 
