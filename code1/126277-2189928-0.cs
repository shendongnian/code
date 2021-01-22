    var query = from product in dc.Products
                let groupMaxPricesQuery = dc.Products.GroupBy(p => p.ProductSubcategoryID)
                                                     .Select(g => g.Max(item => item.ListPrice))
                where groupMaxPricesQuery.Any(listPrice => listPrice <= product.ListPrice)
                select product.Name;
    
    // or
    var query = dc.Products
                  .Select(product => new {
                      Product = product,
                      GroupedMaxPrices = dc.Products.GroupBy(p => p.ProductSubcategoryID)
                                                    .Select(g => g.Max(item => item.ListPrice))
                })
                .Where(item => item.GroupedMaxPrices.Any(listPrice => listPrice <= item.Product.ListPrice))
                .Select(item => item.Product.Name);
