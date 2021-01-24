    private void myDataGrid_CleanUpVirtualizedItem(object sender, CleanUpVirtualizedItemEventArgs e)
    {
    	var row = e.UIElement as DataGridRow;
    	for(int i = 0; i<(sender as DataGrid).Columns.Count; i++)
    	{
    		var cell = (DataGridCell)(sender as DataGrid).Columns[i].GetCellContent(row).Parent;
    		if (cell.Background != Brushes.White) 
    		{
    			e.Cancel = true;
                break;
    		}
    	}            
    }
