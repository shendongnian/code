    //Looping thought datagrid rows & loop though cells and alert cell values
    
    var row = GetDataGridRows(DataGrid_Standard);
    /// go through each row in the datagrid 
    foreach (Microsoft.Windows.Controls.DataGridRow r in row)
    {
    	DataRowView rv = (DataRowView)r.Item;
    	foreach (DataGridColumn column in DataGrid_Standard.Columns)
    	{
    		if (column.GetCellContent(r) is TextBlock)
    		{
    			TextBlock cellContent = column.GetCellContent(r) as TextBlock;
    			MessageBox.Show(cellContent.Text);
    		}
    		else if (column.GetCellContent(r) is CheckBox)
    		{
    			CheckBox chk = column.GetCellContent(r) as CheckBox;
    			MessageBox .Show (chk.IsChecked.ToString());
    		}                      
    	}
    } 
    
    public IEnumerable<Microsoft.Windows.Controls.DataGridRow> GetDataGridRows(Microsoft.Windows.Controls.DataGrid grid)
    {
    	var itemsSource = grid.ItemsSource as IEnumerable;
    	if (null == itemsSource) yield return null;
    	foreach (var item in itemsSource)
    	{
    		var row = grid.ItemContainerGenerator.ContainerFromItem(item) as Microsoft.Windows.Controls.DataGridRow;
    		if (null != row) yield return row;
    	}
    }
