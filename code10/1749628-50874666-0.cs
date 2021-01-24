    DateTime date = DateTime.Today; // or .Now
    var products = context.Products.Join(context.Products,
        p1 => new { p1.Ref01, p1.Ref02, p1.Ref03 },
        p2 => new { p2.Ref01, p2.Ref02, p2.Ref03 },
        (p1, p2) => new { Product = p1, p1.Version, JoinedVersion = p2.Version, JoinedDateApproved = p2.DateApproved } )
        .Where(x=> x.Product.DateObsolete > date && x.JoinedVersion == x.Version+1 && !x.JoinedDateApproved.HasValue)
        .Select(x=>x.Product)
        .ToList();
