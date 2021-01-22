    // This will return a list of all Stock objects having the specified Type
    static List<Stock> GetItemsForType(string type)
    {
        return stock
            .Where(item => item.Type == type)
            .ToList();
    }
    
    // This will return a list of the names of all Type values (no duplicates)
    static List<string> GetStockTypes()
    {
        return stock
            .Select(item => item.Type)
            .Distinct()
            .ToList();
    }
