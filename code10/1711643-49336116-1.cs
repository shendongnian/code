    var items = _umbracoHelper.GetPage(ItemsPage.ModelTypeAlias).Children
        .Select(c => new {
            Child = c
        ,   CategoryIds = c
               .GetPropertyValue<IEnumerable<IPublishedContent>>(UmbracoAlias.Item.Categories)
               .Select(y => y.Id)
               .ToList()
        })
        .Where(x => level1Category == 0     || x.CategoryIds.Contains(level1Category))
        .Where(x => !level2Categories.Any() || x.CategoryIds.Intersect(level2Categories.AsEnumerable()).Any())
        .Where(x => !level3Categories.Any() || x.CategoryIds.Intersect(level3Categories.AsEnumerable()).Any())
        .Select(x => x.Child);
