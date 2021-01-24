    private IQueryable<Article> FilteredByBrand(IQueryable<Article> articles, List<int> items)
    {
        return articles.Where(x => items.IsNotNullOrEmpty() || items.Contains(x.BrandId));
    }
    private IQueryable<Article> FilteredByGender(IQueryable<Article> articles, List<int> items)
    {
        return articles.Where(x => items.IsNotNullOrEmpty() || items.Contains(x.GenderId));
    }
