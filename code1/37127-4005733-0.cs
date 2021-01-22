    public IEnumerable<ICategory> GetSubCategories(long? categoryId)
    {
        var subCategories = this.Repository.Categories.Where(object.Equals(c.ParentId, categoryId))
            .ToList().Cast<ICategory>();
    
        return subCategories;
    }
