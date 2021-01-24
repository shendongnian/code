      QueryContainer baseQuery = Query<ProductDto>.Term(qt => qt.Field(f =>
                                       f.Visible).Value(true));
            baseQuery &= Query<ProductDto>.Term(qt => qt.Field(o => o.ProductSuppliers.Select(a => a.Enabled)).Value(true));
            client.Search<ProductDto>(o => o
               .From(0)
               .Size(10)
               .Query(a => baseQuery));
