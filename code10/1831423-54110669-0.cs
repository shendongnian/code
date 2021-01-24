    Item CreateBrickItemForCustomer(Customer customer)
    {
        Item newItem = new Item();
        
        newItem.Name = "brick",
        newItem.PriceA = customer.PriceA,
        newItem.PriceB = customer.PriceB,
        newItem.PriceC = customer.PriceC,
        
        return newItem;
    }
