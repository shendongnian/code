    items.GroupBy(x => GetTopmostCategory(x))
    ...
    public Category GetTopmostCategory(Item item)
    {
        Category category = item.Category;
        while (category.Parent != null)
        {
            category = category.Parent;
        }
        return category;
    }
