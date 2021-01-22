    private void DataGrid_CellGotFocus(object sender, RoutedEventArgs e)
    {
        // Lookup for the source to be DataGridCell
        if (e.OriginalSource.GetType() == typeof(DataGridCell))
        {
            // Starts the Edit on the row;
            DataGrid grd = (DataGrid)sender;
            grd.BeginEdit(e);
            Control control = GetFirstChildByType<Control>(e.OriginalSource as DataGridCell);
            if (control != null)
            {
                control.Focus();
            }
        }
    }
    private T GetFirstChildByType<T>(DependencyObject prop) where T : DependencyObject
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(prop); i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild((prop), i) as DependencyObject;
            if (child == null)
                continue;
            T castedProp = child as T;
            if (castedProp != null)
                return castedProp;
            castedProp = GetFirstChildByType<T>(child);
            if (castedProp != null)
                return castedProp;
        }
        return null;
    }
