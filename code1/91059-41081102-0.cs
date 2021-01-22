    var orders = db.Orders
                 .GroupBy(o => o.OrderDate)
                 .Select(o => new 
                 {
                    OrderDate = o.Key,
                    OrderCount = o.Count(),
                    Sales = o.Sum(i => i.SubTotal)
                 }
                 .OrderBy(o => o.OrderDate);
