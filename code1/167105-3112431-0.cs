    var namesAndPrices = from category in root.Elements("Category")
                         select new KeyValuePair<string, string>(
                            Name = category.Attribute("BookName").Value,
                            Price = category.Attribute("BookPrice").Value
                         );
    // looping that happens in another function
    // Key = Name
    // Value = Price
    foreach (var nameAndPrice in namesAndPrices)
    {
        // TODO: Output to disk
    }
