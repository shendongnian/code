    public IEnumerable<Category> GetAllChildCats(int categoryid)
    {
    	Category c = Get(categoryid);
    	return new[] { c }.Concat(c.ChildCategories.SelectMany(cat => GetAllChildCats(cat)));
    }
