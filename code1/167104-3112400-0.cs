    var namesAndPrices = from category in root.Elements("Category")
                         select new
                         {
                            Name = category.Attribute("BookName").Value,
                            Price = category.Attribute("BookPrice").Value
                         };
    
    foreach (var nameAndPrice in namesAndPrices)
    {
        // TODO: Output to disk
    }
