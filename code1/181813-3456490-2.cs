    public IList<Category> GetCategoryTreeFromFlattenedCollection(
        IList<FlattenedCategory> flattenedCats, int? parentId)
    {
        List<Category> cats = new List<Category>();
    
        var filteredFlatCats = flattenedCats.Where(fc => fc.ParentId == parentId);
    
        foreach (FlattenedCategory flattenedCat in filteredFlatCats)
        {
            Category cat = new Category();
            cat.CategoryId = flattenedCat.CategoryId;
            cat.Name = flattenedCat.Name;
    
            Ilist<Category> childCats = GetCategoryTreeFromFlattenedCollection(
                flattenedCats, flattenedCat.CategoryId);
    
            cat.Children.AddRange(childCats);
    
            foreach (Category childCat in childCats)
            {
                childCat.Parent = cat;
            }
    
            cats.Add(cat);
        }
    
        return cats;
    }
