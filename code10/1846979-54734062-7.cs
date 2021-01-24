    using (var context = new SuperMarketContext())
    {
        var product = context.Product
            .Include(p => p.Orders)
            .Where(p => p.Id == 5002 && p.Orders.Where(t => t.Total > 10))
            .First();
        
        foreach (var item in product.Orders)
        {
            Console.WriteLine(item);
        }
    }
