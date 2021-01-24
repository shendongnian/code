    using (var context = new SuperMarketContext())
    {
        var product = context.Product
            .Include(p => p.Orders)
            .Where(p => p.Id == 5002)
            .First();
    
        var filteredOrders = context.Entry(product)
            .Collection(p => p.Orders)
            .Query()
            .Where(o => o.Total > 10)
            .Load();
    
        foreach (var item in filteredOrders)
        {
            Console.WriteLine(item);
        }
    }
