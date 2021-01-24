	private void Tab1_Clicked(object sender, MouseButtonEventArgs e)
	{
		if (dg_address.SelectedIndex > -1)
		{
			dg_address.ScrollIntoView(dg_address.Items[dg_address.SelectedIndex]);
			dg_address.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
			{
				DataGridRow row = (DataGridRow)dg_address.ItemContainerGenerator.ContainerFromIndex(dg_address.SelectedIndex);
				row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
			}
			));
		}
	}
	
