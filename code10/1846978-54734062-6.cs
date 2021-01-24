    using (var context = new SuperMarketContext())
    {
        var product = context.Product
            .Include(p => p.Orders)
            .Where(p => p.Id == 5002)
            .First();
    
        var orders = product.Orders.Where(o => o.Total > 10).ToList();
    
        foreach (var item in orders)
        {
            Console.WriteLine(item);
        }
    }
