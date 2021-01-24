    // your original data
	var Items = new List<Item>();
    // those items with status 0
	var itemsToBeRemoved = Items.Where(x => !x.Status);
    // remove those first
	Items.RemoveAll(itemsToBeRemoved.Contains);
    // now find the things with the same name, order by date, get the first one.
	var theOtherItemsToBeRemoved = itemsToBeRemoved.Select(x => 
        Items.Where(y => y.Name == x.Name).OrderBy(y => y.Created).FirstOrDefault()
    ).ToList();
    
    // now remove the items found
	Items.RemoveAll(theOtherItemsToBeRemoved.Contains);
