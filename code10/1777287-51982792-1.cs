    		private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (sender is ListBox lb)
			{
				if (lb.DataContext is YourViewModel vm)
				{
					foreach (var item in e.AddedItems)
					{
						vm.SelectedThings.Add(item);
					}
					foreach (var item in e.RemovedItems)
					{
						vm.SelectedThings.Remove(item);
					}
				}
			}
		}
