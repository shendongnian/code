    var items = db.ItemTables.ToList();
    var itemRelations = db.ItemChildTables.ToList();
			
    var root = items.SingleOrDefault(item => ! itemRelations.Exists(rel => rel.ChildId == item.ItemId));
    if(root != null)
    {
	    Item rootItem = new Item();
	    rootItem.ItemId = root.ItemId;
        List<Item> childLessItems = new List<Item>{ rootItem };
    	while(childLessItems.Count > 0)
    	{
	    	List<Item> newChildLessItems = new List<Item>();
    		foreach(var parent in childLessItems)
	    	{
	    		var childIds = 	from rel in itemRelations
	    						where rel.ParentID == parent.ItemId
	    						select rel.ChildId;
	    		var children = items.Where(maybeChild => childIds.Contains(maybeChild.ItemId));
    			foreach(var child in children)
    			{
    				Item childItem = new Item();
    				childItem.ItemId = child.ItemId;
    				childItem.Parents.Add(parent);
        				parent.ChildItems.Add(childItem);
	    			newChildLessItems.Add(child);
	    		}
	    	}
	    	childLessItems = newChildLessItems;
	    }
    }
