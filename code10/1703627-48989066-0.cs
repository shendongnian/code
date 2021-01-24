    private static void Grid_Sorting(object sender, DataGridSortingEventArgs e)
    {
    	var grid = ((DataGrid)sender);
    	var cView = CollectionViewSource.GetDefaultView(grid.ItemsSource);
    
    	//Alternate between ascending/descending if the same column is clicked 
    	var direction = ListSortDirection.Ascending;
    	if (cView.SortDescriptions.Count >= 2 && cView.SortDescriptions[1].PropertyName == e.Column.SortMemberPath)
    		direction = cView.SortDescriptions[1].Direction == ListSortDirection.Descending ? ListSortDirection.Ascending : ListSortDirection.Descending;
    
    	cView.SortDescriptions.Clear();
    	cView.SortDescriptions.Add(new SortDescription("_sort", ListSortDirection.Ascending));
    	grid.Columns.First(c => c.SortMemberPath == "_sort").SortDirection = ListSortDirection.Ascending;
    	cView.SortDescriptions.Add(new SortDescription(e.Column.SortMemberPath, direction));
    	grid.Columns.First(c => c.SortMemberPath == e.Column.SortMemberPath).SortDirection = direction;
    
    	e.Handled = true;
    }
