    var products = db.Items
                     .Select(p => new ProductVm
                                   {
                                      Id = p.Id,
                                      Code = p.Code,
                                      RemainingQuantity = p.Quantity - p.Orders
                                                                        .Sum(n => n.Quantity)
                                   }).ToList();
