    List<ListItem> items = new List<ListItem>();
    
    while(dr.Read())
    {
    	string firstItem = Convert.ToString(dr["FIRST_ITEM"]);
    	if(!string.IsNullOrEmpty(firstItem))
    	{
    		ListItem thisItem = new ListItem(firstItem, firstItem);
    		items.Add(thisItem);
    	}
    }
    
     machineName.Items = items;
