    private ListSortDirection _direction = ListSortDirection.Descending;
    private void dg_Sorting(object sender, DataGridSortingEventArgs e)
    {
        e.Handled = true;
        DataGrid dataGrid = (DataGrid)sender;
        ICollectionView view = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);
        _direction = _direction == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
        view.SortDescriptions.Clear();
        view.SortDescriptions.Add(new SortDescription("YourBoolProperty", ListSortDirection.Descending));
        view.SortDescriptions.Add(new SortDescription(e.Column.SortMemberPath, _direction));
        e.Column.SortDirection = _direction;
    }
