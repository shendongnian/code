    var inventories = from inv in AppContext.Inventories
                      group inv by new { i.LocationId, i.ProductId } into g
                      let firstInv = g.FirstOrDefault()
                      let firstPur = AppContext.Inventories
                                            .Where(i => i.ProductId == g.Key.ProductId)
                                            .OrderByDescending(i => i.DateAdded)
                                            .FirstOrDefault()
                      select new InventoryAvailableQuantity
                      {
                          ProductId = g.Key.ProductId,
                          LocationId = g.Key.LocationId,
                          Product = firstInv.Product.Name,
                          Location = firstInv.Location.Name,
                          PurchasePrice = firstPur.PurchasePrice,
                          ResellerPrice = firstPur.ResellerPrice,
                          RetailPrice = firstPur.RetailPrice
                      }; // ( select ... { ... }).ToList(); if you will
