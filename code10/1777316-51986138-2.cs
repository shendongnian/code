    private IQueryable<Article> FilteredByBrand(IQueryable<Article> articles, List<int> items)
    {
        return items.IsNullOrEmpty() ? articles : articles.Where(x => items.Contains(x.BrandId));
    }
    private IQueryable<Article> FilteredByGender(IQueryable<Article> articles, List<int> items)
    {
        return items.IsNullOrEmpty() ? articles : articles.Where(x => items.Contains(x.GenderId));
    }
