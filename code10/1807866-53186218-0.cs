    using System.Linq;
    
    //Search the list to see if the name exists
    //Note, SingleOrDefault throws an error if more than one result is found.
    Item updateItem = Items.SingleOrDefault(i => i.Name == itemName);
    
    //Check if the Item exists in the list
    if(updateItem != null)
    {
        //If it does, update the time
    	updateItem.NOWDATE = newDate;
    }
    else
    {
        //If it doesn't, add a new Item
        Item.Insert(0, new Item
        {
            NOWDATE = DateTime.Now.ToString(dateformat),
            Name = itemName     
        }
    }
    
    //Now, sort the items so the ones with the earlier date appear first
    Items = Items.OrderByDescending(i => i.NEWDATE);
