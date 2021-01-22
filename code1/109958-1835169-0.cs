    var query = productList
       .GroupBy(r => r.Region)
       .Select(group => new { Region = group.Key,
                              Orders = group.OrderByDescending(p => p.ProductPrice).
                                            .Take(2) });
