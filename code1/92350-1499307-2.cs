	/// <summary>
	/// Handles the DataGrid's Loaded event.
	/// </summary>
	/// <param name="sender">Sender object.</param>
	/// <param name="e">Event args.</param>
	private static void Grid_Loaded(object sender, RoutedEventArgs e)
	{
		DataGrid grid = sender as DataGrid;
		DependencyObject dep = grid;
		// Navigate down the visual tree to the button
		while (!(dep is Button))
		{
			dep = VisualTreeHelper.GetChild(dep, 0);
		}
		Button button = dep as Button;
		// apply our new template
		ControlTemplate template = GetSelectAllButtonTemplate(grid);
		button.Template = template;
		button.Command = null;
		button.Click += new RoutedEventHandler(SelectAllClicked);
	}
	/// <summary>
	/// Handles the DataGrid's select all button's click event.
	/// </summary>
	/// <param name="sender">Sender object.</param>
	/// <param name="e">Event args.</param>
	private static void SelectAllClicked(object sender, RoutedEventArgs e)
	{
		Button button = sender as Button;
		DependencyObject dep = button;
		
		// Navigate up the visual tree to the grid
		while (!(dep is DataGrid))
		{
			dep = VisualTreeHelper.GetParent(dep);
		}
					
		DataGrid grid = dep as DataGrid;
		if (grid.SelectedItems.Count < grid.Items.Count)
		{
			grid.SelectAll();
		}
		else
		{
			grid.UnselectAll();
		}
		e.Handled = true;
	}
