    private void MyDataGrid_OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        if (e.EditAction == DataGridEditAction.Commit)
        {
                DependencyObject depObj = e.EditingElement;
                while (depObj != null && !(depObj is DataGridCell)) {
                    depObj = VisualTreeHelper.GetParent (depObj);
                }
                if (depObj != null) {
                    DataGridCell gridCell = (DataGridCell) depObj;
                    gridCell.Foreground = Brushes.Red;
                }
        }
    }
