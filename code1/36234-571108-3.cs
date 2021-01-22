    void listView_ItemCreated(object sender, ListViewItemEventArgs e)
		{
			if ( listView.SelectedIndex > -1 ) return;
			object idx = Request.QueryString["idx"];
			ListViewDataItem item = e.Item as ListViewDataItem;
			if (item != null && listView.DataKeys[item.DataItemIndex].Value.Equals(idx) )
			{
				listView.SelectedIndex = item.DisplayIndex;
				e.Item.Controls.Clear();
				listView.SelectedItemTemplate.InstantiateIn(e.Item);
			}
		}
