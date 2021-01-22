    private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        DataGrid dataGrid = sender as DataGrid;
        if (e.AddedItems!=null && e.AddedItems.Count>0)
        {
            // find row for the first selected item
            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(e.AddedItems[0]);
            if (row != null)
            {
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);
                // find grid cell object for the cell with index 0
                DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(0) as DataGridCell;
                if (cell != null)
                {
                    Console.WriteLine(((TextBlock)cell.Content).Text);
                }
            }
        }
    }
    
    static T GetVisualChild<T>(Visual parent) where T : Visual
    {
        T child = default(T);
        int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
        for (int i = 0; i < numVisuals; i++)
        {
            Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
            child = v as T;
            if (child == null) child = GetVisualChild<T>(v);
            if (child != null) break;
        }
        return child;
    }
