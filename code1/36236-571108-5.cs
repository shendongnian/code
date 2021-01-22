    void listView_ItemCreated(object sender, ListViewItemEventArgs e)
	{
		// exit if we have already selected an item; This is mainly helpful for
		// postbacks, and will also serve to stop processing once we've found our
		// key; Optionally we could remove the ItemCreated event from the ListView 
		// here instead of just returning.
		if ( listView.SelectedIndex > -1 ) return; 
		ListViewDataItem item = e.Item as ListViewDataItem;
		// check to see if the item is the one we want to select (arbitrary) just return true if you want it selected
		if (DoSelectDataItem(item)==true)
		{
			// setting the SelectedIndex is all we really need to do unless 
			// we want to change the template the item will use to render;
			listView.SelectedIndex = item.DisplayIndex;
			if ( listView.SelectedItemTemplate != null )
			{
				// Unfortunately ListView has already a selected a template to use;
				// so clear that out
				e.Item.Controls.Clear();
				// intantiate the SelectedItemTemplate in our item;
				// ListView will DataBind it for us later after ItemCreated has finished!
				listView.SelectedItemTemplate.InstantiateIn(e.Item);
			}
		}
	}
	
	bool DoSelectDataItem(ListViewDataItem item)
	{
		return item.DisplayIndex == 0; // selects the first item in the list (this is just an example after all; keeping it simple :D )
	}
