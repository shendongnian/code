    var identicals = orderList.SelectMany(x => x.Lines)
                      .GroupBy(x => x, new OrderLineEqualityComparer())
                      .Where(g => g.Count() > 1)
                      .Select(g => new {
                            Count = g.Count(),
                            OrderItem = g.Key
                      })
                      .ToList();
