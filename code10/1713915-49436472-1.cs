    var lineItemsList = ABCDetails.ABCLineItemsAuto.ToList();
    
    // Use a copy of the list in your foreach condition
    foreach (var item in lineItemsList.ToList())
    {
        if (filterItemsDB.Any(c => c.itemCODE == item.itemType))
        {
            // Do something here, details aren't relevant to this question
        }
        else
        {
            lineItemsList.Remove(item);
        }
    }
    ABCDetails.ABCLineItemsAuto = lineItemsList.ToArray();
