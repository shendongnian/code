    private void txtSearchMenu_TextChanged(object sender, EventArgs e)
    {
    	string searchVal = txtSearchMenu.Text.ToLower();
    	if (searchVal != "")
    	{
    		foreach (ListViewItem item in lvMenuItems.Items)
    		{
    			foreach (ListViewItem.ListViewSubItem subSearch in item.SubItems)
    			{
    				if (subSearch.Text.ToLower().Contains(searchVal) == true)
    				{
    					subSearch.BackColor = Color.MediumAquamarine;
    				}
    				else
    				{
    					subSearch.BackColor = Color.White;
    				}
    			}
    			item.UseItemStyleForSubItems = false;
    		}
    	}
    	else
    	{
    		foreach (ListViewItem item in lvMenuItems.Items)
    		{
    			foreach (ListViewItem.ListViewSubItem subSearch in item.SubItems)
    			{
    				subSearch.BackColor = Color.White;
    			}
    		}
    	}
    }
