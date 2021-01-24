    private void ReleaseDataGrid_Sorting(object sender, DataGridSortingEventArgs e)
    {
        if (e.Column.SortMemberPath == "ReleaseInfo")
        {
            e.Handled = true;
            ListSortDirection direction = (e.Column.SortDirection != ListSortDirection.Ascending) ? ListSortDirection.Ascending : ListSortDirection.Descending;
            e.Column.SortDirection = direction;
            //sort according to your logic...
        }
    }
