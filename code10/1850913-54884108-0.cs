    var ordersWithLatestDate = orders.GroupBy(x => x.Id)
                                .Select( g => new 
                                    { 
                                        Orderid = g.Key, 
                                        OrderDateTime = g.OrderByDescending(x => x.OrderDateTime)
                                                         .Select(y => y.OrderDateTime)
                                                         .First()
                                        });
