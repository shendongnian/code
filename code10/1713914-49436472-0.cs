    // Use a copy of the list in your foreach condition
    foreach (var item in ABCDetails.ABCLineItemsAuto.ToList())
    {
        if (filterItemsDB.Any(c => c.itemCODE == item.itemType))
        {
            // Do something here, details aren't relevant to this question
        }
        else
        {
            ABCDetails.ABCLineItemsAuto.Remove(item);
        }
    }
