    var identicalOrders = orderList.GroupBy(x => x)
                                   .Where(g => g.Count() > 1)
                                   .Select(g => new
                                   {
                                       Count = g.Count(),
                                       OrderItems = g.Key.Lines,
                                       OrderNumbers = orderList.Where(x => x.Equals(g.Key))
                                                               .Select(x => x.OrderNumber)
                                                               .ToList()
                                   })
                                   .ToList();
