    private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
    	e.Cancel = true;
    	(sender as DataGrid).Dispatcher.BeginInvoke((Action)(()=>
    		{
    			(sender as DataGrid).SelectedIndex = e.Row.GetIndex();
    			e.EditingElement.Focus();
    		}
    	));
    }
