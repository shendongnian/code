            var inventories = Inventories
                .GroupBy(i => new {i.LocationId, i.ProductId})
                .Select(g => new
                {
                    g.Key.ProductId,
                    g.Key.LocationId,
                    CurrentInventories = g.FirstOrDefault(),
                    LastInventories = Inventories.Where(i => i.ProductId == g.Key.ProductId).OrderByDescending(i => i.DateAdded).FirstOrDefault()
                })
                .Select(g => new InventoryAvailableQuantity
                {
                    ProductId = g.ProductId,
                    LocationId = g.LocationId,
                    Product = g.CurrentInventories.Product.Name,
                    Location = g.CurrentInventories.Location.Name,
                    PurchasePrice = g.LastInventories.PurchasePrice,
                    ResellerPrice = g.LastInventories.ResellerPrice,
                    RetailPrice = g.LastInventories.RetailPrice
                })
                .ToList();
