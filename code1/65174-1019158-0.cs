    protected void uxListView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            ListViewDataItem item = (ListViewDataItem)e.Item;
    
            // Get the bound object (KeyValuePair from the dictionary)
            KeyValuePair<string, List<int>> nestedIntegerList = (KeyValuePair<string, List<int>>)item.DataItem;
    
            // Get our nested ListView for this Item
            ListView nestedListView = (ListView)e.Item.FindControl("uxNestedListView");
            // Check the number of items
            if (nestedIntegerList.Value.Count > 5)
            {
                // There are more items than we want to show, so show the "More..." button
                LinkButton button = (LinkButton)item.FindControl("uxMore");
                button.Visible = true;
            }
            
            // Bind the nestedListView to wahtever you want 
            nestedListView.DataSource = nestedIntegerList.Value.Take(5);
            nestedListView.DataBind();
        }
    }
