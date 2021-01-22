    public IEnumerable<ICategory> GetSubCategories(long? categoryId)
    {
        var subCategories = this.Repository.Categories.Where(c => (!categoryId.HasValue && c.ParentId == null) || c.ParentId == categoryId)
            .ToList().Cast<ICategory>();
    
        return subCategories;
    }
