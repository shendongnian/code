    Item createItemForCustomer(Customer customer)
    {
        double factorA = 1.01;
        double factorB = 1.2;
        double factorC = 1.6;
        Item newItem = new Item();
        
        newItem.Name = "brick",
        newItem.PriceA = customer.PriceA * factorA,
        newItem.PriceB = customer.PriceB * factorB,
        newItem.PriceC = customer.PriceC * factorC,
        
        return newItem;
    }
