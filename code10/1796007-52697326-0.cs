	IEnumerable<IPublishedContent> getAllProducts = UmbracoAssignedContentHelper.PageContentByAlias("productCatalog").Children;
	
	var result = getAllProducts.GroupBy(x => new { Manufacturer = x.GetPropertyValue<string>("manufacturer"), Category = x.GetPropertyValue<string>("category")})
		.Select(b => new ProductsGroupByTypeViewModel
		{
			GetAllProductsGroupByType   = new List<string>(),
			Category                    = b.Key.Category,
			Manufacturer                = b.Key.Manufacturer
	
		}).ToList();
	
	froeach(var item in result)
	{
		item.GetAllProductsGroupByType = getAllProducts.Where(en => en.manufacturer == item.Manufacturer && en.category == item.Category).Select(en => en.product).ToList();
	}
	
	//now you can use result as your answer
