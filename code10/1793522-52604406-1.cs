    <DataGrid.Resources>
        <Style TargetType="DataGridCell">
            <EventSetter Event="PreviewMouseLeftButtonDown" Handler="PreviewMouseDown"/>
        </Style>
    </DataGrid.Resources>
    private void PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
    	var cell = sender as DataGridCell; if (cell == null) { return; }
    	DataGridRow parGridRow = null;
    	var visParent = VisualTreeHelper.GetParent(cell);
    	while (parGridRow == null && visParent != null)
    	{
    		parGridRow = visParent as DataGridRow;
    		visParent = VisualTreeHelper.GetParent(visParent);
    	}
    	if (parGridRow == null) { return; }
    	var selectedItem = (parGridRow.DataContext as BillItemInSerie);
    	var obj = serialNumbersIn.FirstOrDefault(sn => selectedItem.DocumentItemInSeriesId == sn.DocumentItemInSeriesId);
    	obj.IsChecked= (bool)!obj.IsChecked;
    
    	//e.Handled = true;
    }
