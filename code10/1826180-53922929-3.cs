    var productList = dbContext.FactorItems.GroupBy(fi => new { fi.ProductId, fi.Product.Name }).Select(g => new
            {
                ProductId = g.Key.ProductId,
                ProductName = g.Key.Name,
                TotalSoldQty = g.Sum(x => x.Qty)
            }).OrderByDescending(x => x.TotalSoldQty).ToList();
