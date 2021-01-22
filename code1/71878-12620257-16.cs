    Order CopyOrderWithNewPK(Order item)
    {
        Order newItem = item.CreateCopy(); // use ext. method to copy properties
        newItem.OrderId = new Guid(); // create new primary key for the item
        return newItem;
    }
