    using (var db = new DBDataContext())
    {
        // Step 1 - get the item from the data context
        var product = db.Products.Where(p => p.ID == productID).SingleOrDefault();
        if (product == null) //Error checking
        {
            throw new ArgumentException();
        }
    
        // Step 2 - change whatever values you want to update
        product.Price = 100;
    
        // Step 3 - submit the changes
        db.SubmitChanges();
    }
