    //
    // SINGLE CLICK EDITING
    //
    private void DataGridCell_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DataGridCell cell = sender as DataGridCell;
        if (cell != null && !cell.IsEditing && !cell.IsReadOnly)
        {
            if (!cell.IsFocused)
            {
                cell.Focus();
            }
            DataGrid dataGrid = FindVisualParent<DataGrid>(cell);
            if (dataGrid != null)
            {
                if (dataGrid.SelectionUnit != DataGridSelectionUnit.FullRow)
                {
                    if (!cell.IsSelected)
                        cell.IsSelected = true;
                }
                else
                {
                    DataGridRow row = FindVisualParent<DataGridRow>(cell);
                    if (row != null && !row.IsSelected)
                    {
                        row.IsSelected = true;
                    }
                }
            }
        }
    }
    
    static T FindVisualParent<T>(UIElement element) where T : UIElement
    {
        UIElement parent = element;
        while (parent != null)
        {
            T correctlyTyped = parent as T;
            if (correctlyTyped != null)
            {
                return correctlyTyped;
            }
            
            parent = VisualTreeHelper.GetParent(parent) as UIElement;
        }
        
        return null;
    }
