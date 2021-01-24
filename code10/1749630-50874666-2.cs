    // given products is an IQueryable representing the filtered products...
    DateTime date = DateTime.Today; // or .Now
    
    var productList = products.ToList(); // Materialize the EF Queryable into list of entities.
    
        productList = productList.Join(productList,
            p1 => new { p1.Ref01, p1.Ref02, p1.Ref03 },
            p2 => new { p2.Ref01, p2.Ref02, p2.Ref03 },
            (p1, p2) => new { Product = p1, p1.Version, JoinedVersion = p2.Version, JoinedDateApproved = p2.DateApproved } )
            .Where(x=> x.Product.DateObsolete > date && x.JoinedVersion == x.Version+1 && !x.JoinedDateApproved.HasValue)
            .Select(x=>x.Product)
            .ToList();
