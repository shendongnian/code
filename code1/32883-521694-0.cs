    private void AddOrUpdateListItem(DomainModelObject item)
    {
    	ListViewItem li = lvwListView.Items[GetKey(item)];
    
    	if (li == null)
    	{
    		li = new ListViewItem
    				 {
    					 Name = GetKey(item), 
    					 Tag = item
    				 };
    		li.SubItems.Add(new ListViewItem.ListViewSubItem());
    		li.SubItems.Add(new ListViewItem.ListViewSubItem());
    		li.SubItems.Add(new ListViewItem.ListViewSubItem());
    		li.ImageIndex = 0;
    		lvwListView.Items.Add(li);
    	}
    
    	li.Text = [Itemtext];
    	li.SubItems[1].Text = [Itemtext];
    	li.SubItems[2].Text = [Itemtext];
    	li.SubItems[3].Text = [Itemtext];
    }
