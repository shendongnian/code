    public List<Category> GetAllChildCats(int categoryId)
    {
        List<Category> ret = new List<Category>();
        GetAllChildCats(categoryId, ret);
        return ret;
    }
    private void GetAllChildCats(int categoryId, List<Category> list)
    {
        Category c = Get(categoryid);
        list.Add(c);
        foreach(Category cat in c.ChildCategories)
        {
            GetAllChildCats(cat.CategoryID);
        }
    }
