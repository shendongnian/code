    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		foreach (var item in e.AddedItems.OfType<ListViewItem>())
		{
			Trace.WriteLine("ListViewItem Selected");
			item.IsSelected = false;
		}
	}
