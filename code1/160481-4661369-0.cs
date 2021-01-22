    private void dataGrid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
	{
		var dep = (DependencyObject)e.OriginalSource;
		// iteratively traverse the visual tree
		while ((dep != null) &&
			!(dep is DataGridRow))
		{
			dep = VisualTreeHelper.GetParent(dep);
		}
		if (dep == null)
			return;
		if (dep is DataGridRow)
		{
			var row = dep as DataGridRow;
			row.IsSelected = !row.IsSelected;
			e.Handled = true;
		}
	}
