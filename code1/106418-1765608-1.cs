    private void dataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
    {
        foreach (DataGridCellInfo cellInfo in dataGrid1.SelectedCells)
        {
            // this changes the cell's content not the data item behind it
            DataGridCell gridCell = TryToFindGridCell(dataGrid1, cellInfo);
            if (gridCell!=null) gridCell.Content = "changed!!!"; 
        }
    }
    static DataGridCell TryToFindGridCell(DataGrid grid, DataGridCellInfo cellInfo)
    {
        DataGridCell result = null;
        DataGridRow row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromItem(cellInfo.Item);
        if (row!=null)
        {
            int columnIndex = grid.Columns.IndexOf(cellInfo.Column);
            if (columnIndex>-1)
            {
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);
                result = presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex) as DataGridCell;
            }
        }
        return result;
    }
    static T GetVisualChild<T>(Visual parent) where T : Visual
    {    
        T child = default(T);    
        int numVisuals = VisualTreeHelper.GetChildrenCount(parent);    
        for (int i = 0; i < numVisuals; i++)    
        {        
            Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);        
            child = v as T;        
            if (child == null)        
            {            
                child = GetVisualChild<T>(v);        
            }        
            if (child != null)        
            {            
                break;        
            }    
        }    
        return child;
    }
