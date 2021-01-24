    var deleteList = ExistingItems.Where(ei => !NewItemList.Any(ni => ni.ID == ei.ID ));
    
    var updateList = ExistingItems.Where(ei => NewItemList.Any(ni => ni.ID == ei.ID ));
    
    var addList = NewItemList.Where(ni => !ExistingItems.Any(ei => ei.ID == ni.ID ));
