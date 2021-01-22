    int index = 3;
    dataGrid.ScrollIntoView(dataGrid.Items[index]);
    DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(dataGrid.Items[index]);
    if (row != null)
    {
        DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);
        DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(2);
        if (cell != null)
        {
            cell.IsSelected = true;
            cell.Focus();
        }
    }
