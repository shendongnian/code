    IEnumerable<IPublishedContent> getAllProducts = UmbracoAssignedContentHelper.PageContentByAlias("productCatalog").Children;
    
    var result = getAllProducts.GroupBy(x => new { Manufacturer = x.GetPropertyValue<string>("manufacturer"), Category = x.GetPropertyValue<string>("category")})
        .Select(b => new ProductsGroupByTypeViewModel
        {
            GetAllProductsGroupByType   = b.Select(bn => bn.GetPropertyValue<List<string>>("product")),
            Category                    = b.Key.Category,
            Manufacturer                = b.Key.Manufacturer
    
        }).ToList();
    
    var listOfProducts = result.ToList();  
