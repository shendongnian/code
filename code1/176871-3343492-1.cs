    var facetTypeIds = new [] { 1, 4, ... };
    var predicate = PredicateBuilder.True<Product>();
    foreach (int id in facetTypeIds)
    {
        int facetId = id; // avoid capturing loop variable
        predicate = predicate.And( p => p.FacetTypes.Any( x => x.FacetTypeId == facetId );
    }
    var products = sc.Products
                     .Where( p => p.ProductType.SysName == productTypeSysName )
                     .Where( predicate );
