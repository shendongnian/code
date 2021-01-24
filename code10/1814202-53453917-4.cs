    private void dgMain_Loaded(object sender, RoutedEventArgs e)
        {
            DataGrid workinggrid = sender as DataGrid;
            ExpandoObject SingleExpando = (workinggrid.ItemsSource as List<ExpandoObject>).FirstOrDefault();
            if (workinggrid == null) workinggrid = new DataGrid();
            List<string> ColumHeaders = (SingleExpando as IDictionary<string, object>).ToList().Select(p => p.Key).ToList();
            foreach (string ColumnName in ColumHeaders)
            {
                var newcolumn = new DataGridTextColumn() { Header = ColumnName, Binding = new Binding(ColumnName) };
                workinggrid.Columns.Add(newcolumn);
            }
        }
