    var categories = from p in products
                     group p by p.Category into g
                       let  minPrice = g.Min(p => p.UnitPrice)
                     select new {
                                  Category = g.Key,
                                  CheapestProducts = g.Where(p => p.UnitPrice == minPrice)
                                };
