    public void CreateField(Grid MainGrid, TextBox Columns, TextBox Rows) // TextBox WHeight, TextBox WWidth, MainWindow MainWindow)
    {
       var ColumnCount = int.Parse(Columns.Text);
       var RowCount = int.Parse(Rows.Text);
       var width = MainGrid.ActualWidth;
       var height = MainGrid.ActualHeight;
    
       for (var a = 0; a <= ColumnCount; a++)
       {
          var c = new ColumnDefinition();
          c.Width = new GridLength(width / ColumnCount, GridUnitType.Pixel);
          MainGrid.ColumnDefinitions.Add(c);
       }
       for (var a = 0; a <= RowCount; a++)
       {
          var r = new RowDefinition();
          r.Height = new GridLength(height / RowCount, GridUnitType.Pixel);
          MainGrid.RowDefinitions.Add(r);
       }
    }
    
    private void ButtonCreate_OnClick(object sender, RoutedEventArgs e)
    {
       CreateField(MainWindowGrid, txtColums, txtRows);
    }
