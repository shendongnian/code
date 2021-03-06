    var productList = products.ToList(); // Materialize the EF Queryable into list of entities.
    
    // Fetch a list of applicable product IDs.
    var productIds = productList.Join(productList,
        p1 => new { p1.Ref01, p1.Ref02, p1.Ref03 },
        p2 => new { p2.Ref01, p2.Ref02, p2.Ref03 },
        (p1, p2) => new { ProductId = p1.ProductId, DateObsolete = p1.DateObsolete, p1.Version, JoinedVersion = p2.Version, JoinedDateApproved = p2.DateApproved } )
        .Where(x=> x.DateObsolete > date && x.JoinedVersion == x.Version+1 && !x.JoinedDateApproved.HasValue)
        .Select(x=>x.ProductId)
        .ToList();
    
    // Filter the original IQueryable.
    products = products.Where(x => productIds.Contains(x.ProductId));
