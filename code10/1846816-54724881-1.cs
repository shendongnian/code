    public static Func<Item, bool> InCategoryOrSubCategory(Category category) 
    {
    	return item => 
    		item.CategoryId == category.Id || 
    		category.Children.Any(subCategory => InCategoryOrSubCategory(subCategory)(item));
    }
