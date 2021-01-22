    Customer CopyCustomerWithNewPK(Customer item)
    {
        Customer newItem = item.CreateCopy(); // use ext. method to copy properties
        newItem.CustomerId = new Guid(); // create new primary key for the item
        return newItem;
    }
