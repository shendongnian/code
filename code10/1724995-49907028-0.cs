    var list = dbContext.PurchaseItems
        .Where( x => x.CompanyId == 1 )
        .GroupBy( x => x.PurchaseItemPrice )
        .Select( grp => new {
            PurchaseItemPrice = grp.Key,
            WarehouseId       = grp.Max( x => x.WarehouseId ),
            CompanyId         = grp.Max( x => x.CompanyId ),
            ProductId         = grp.Max( x => x.ProductId ),
            AvailableQuantity = grp.Sum( x => x.AvailableQuantity ),
        } )
        .OrderBy( output => output.ProductId )
        .ToList();
