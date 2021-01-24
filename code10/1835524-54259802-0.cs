    return db.Products.Select(p => new {Order = p.InternalOrder, Prod = p})
             .OrderBy(p => p.Order)        
             .Select(p => new Product {
            {
                 Id = p.Prod.Id,
                 MarketName = p.Prod.MarketName
            })
            
            .ToArray();
