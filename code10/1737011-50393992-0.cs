    public List<Category> ContainsResources(List<Category> query) =>
        query.Where(c => c.ExternalResources.Any(r => r.IsInActivity))
             .Select(c => new Category
                     {
                         CategoryID = c.CategoryID,
                         Name = c.Name,
                         ParentCategoryID = c.ParentCategoryID,
                         ExternalResources = c.ExternalResources.Where(r => r.IsInActivity).ToList()
                     })
             .ToList();
