    protected void DataGridRow_MouseDown(object sender, MouseButtonEventArgs e)
    {
        // GetVisualChild<T> helper method, simple to implement
        DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);
        // try to get the first cell in a row
        DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(0);
        if (cell != null)
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(MouseLeftButtonDownEvent);
            //if the DataGridSelectionUnit is set to FullRow this will have the desired effect
            RaiseEvent(e);
        }
    }
