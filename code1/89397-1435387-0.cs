    public IQueryable GetCategories(Category parent)
    {
        var cats = (parent.Categories);
        foreach (Category c in cats )
        {
            cats  = cats .Concat(GetCategories(c));
        }
        return a;
    }
