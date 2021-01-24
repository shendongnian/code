    var firstOrders = Orders.GroupBy(x=>x.CustomerName)
                     .Select(c => c.OrderBy(x=>x.OrderDate).First());
    
    var lastOrders = Orders.GroupBy(x=>x.CustomerName)
                    .Select(c => c.OrderByDescending(x=>x.OrderDate).First());
