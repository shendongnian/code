    public static bool InCategoryOrSubCategory(Item item, Category category)
    {
    	return item.CategoryId == category.Id ||
    		category.Children.Any(subCategory => InCategoryOrSubCategory(item, subCategory));
    }
