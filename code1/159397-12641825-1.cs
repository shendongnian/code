	private IEnumerable<Photo> GetVisibleItems()
	{
		var items = new List<Photo>();
		foreach (Photo item in PhotosListBox.Items)
		{
			if (IsUserVisible((ListBoxItem) PhotosListBox.ItemContainerGenerator.ContainerFromItem(item), ParentGrid))
			{
				items.Add(item);
			}
			else if (items.Any())
			{
				break;
			}
		}
		return items;
	}
