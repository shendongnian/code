    var items = _umbracoHelper.GetPage(ItemsPage.ModelTypeAlias).Children
        .Where(c => {
            var categoryIds = c
               .GetPropertyValue<IEnumerable<IPublishedContent>>(UmbracoAlias.Item.Categories)
               .Select(y => y.Id)
               .ToList();
            if (level1Category != 0 && !categoryIds.Contains(level1Category)) {
                return false;
            }
            if (level2Categories.Any() && !categoryIds.Intersect(level2Categories.AsEnumerable()).Any()) {
                return false;
            }
            if (level3Categories.Any() && !categoryIds.Intersect(level3Categories.AsEnumerable()).Any()) {
                return false;
            }
            return true;
        });
