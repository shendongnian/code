    var groupedOrders = orders.GroupBy(o => o.OrderName)
                              .Select(g => new ListContent {
                                               OrderName = g.Key,
                                               OrderValue = g.Sum(o => o.OrderValue)
                                           })
                              .ToList();
