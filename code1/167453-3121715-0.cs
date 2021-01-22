    private void FindDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
    
            int selectedIndex = dataGrid.SelectedIndex;
            if (selectedIndex > -1)
            {
                FindResult findResult = (FindResult)FindDetailsDataGrid.SelectedItem;
    
                DataGridColumn column = dataGrid.Columns[0];
                FrameworkElement fe = column.GetCellContent(dataGrid.SelectedItem);
                FrameworkElement result = GetParent(fe, typeof(DataGridCell));
    
                if (result != null)
                {
                    DataGridCell cell = (DataGridCell)result;
                    //changes the forecolor
                    cell.Foreground = new SolidColorBrush(Colors.Blue);
                    //how to get cell value?
    
                    TextBlock block = fe as TextBlock;
                    if (block != null)
                    {
                        string cellText = block.Text;
                        MessageBox.Show(cellText);
                    }
                }
            }
        }
