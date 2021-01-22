    public void GetAllChildCategories(ProductCategory ParentCategory)
    {
        ParentCategory.ChildCategories = GetChildCategories(ParentCategory.ID);
        foreach(ProductCategory cat in ParentCategory.ChildCategories)
        {
            GetAllChildCategories(cat);
        }
    }
