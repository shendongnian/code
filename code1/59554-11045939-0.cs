		private void positionsListView_DoubleClick(object sender, EventArgs e)
		{
			if (positionsListView.SelectedItems.Count == 1)
			{
				ListView.SelectedListViewItemCollection items = positionsListView.SelectedItems;
				ListViewItem lvItem = items[0];
				string what = lvItem.Text;
			}
		}
