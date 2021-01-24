    var query2 = _context.Products.Join(_context.ProductInfos, c => c.Id, a => a.ProductId, (a, c) => new
    {
        Id = a.Id,
        ItemName = a.ItemName,
        CategoryName = a.Category.CategoryName,
        UnitName = a.Unit.UnitName,
        UnitValue = a.UnitSize,
        Quantity = a.Quantity,
        CostPrice = c.PurchasePrice,
        SalePrice = c.SalePrice,
        EntryDate = c.EntryDate,
        ExpireDate = c.ExpireDate
    }).Max(x => x.Id);
