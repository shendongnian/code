    var holdingList = new List<Holding>()
    {
          new Holding() { Quantity = 2, Price = 5 },
          new Holding() { Quantity = 7, Price = 2 },
          new Holding() { Quantity = 1, Price = 3 }
    };
    
    var lookup = new Dictionary<PortfolioSheetMapping, Func<Holding, int>>()
    {
          { PortfolioSheetMapping.Price, new Func<Holding, int>(x => x.Price) },
          { PortfolioSheetMapping.Symbol, new Func<Holding, int>(x => x.Symbol) },
          { PortfolioSheetMapping.Quantitiy, new Func<Holding, int>(x => x.Quantity) }
    };
                
    Console.WriteLine("Original values:");
    foreach (var sortedItem in holdingList)
    {
        Console.WriteLine("Quantity = {0}, price = {1}", sortedItem.Quantity, sortedItem.Price);
    }
    
    var item = PortfolioSheetMapping.Price;
    Func<Holding, int> action;
    if (lookup.TryGetValue(item, out action))
    {
        Console.WriteLine("Values sorted by {0}:", item);
        foreach (var sortedItem in holdingList.OrderBy(action))
        {
             Console.WriteLine("Quantity = {0}, price = {1}", sortedItem.Quantity, sortedItem.Price);
        }
    }
