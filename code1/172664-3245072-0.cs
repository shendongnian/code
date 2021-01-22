    public class Category
    {
    	public int Id;
    }
    
    public class CategoriesRow
    {
    	public int Id;
    }
    
    public List<Category> RemoveNotUsedCategories(List<Category> categoryList, List<CategoriesRow> Categories)
    {
    	List<Category> usedCategories = new List<Category>();
    
    	foreach (Category usableCat in categoryList)
    	{
    		foreach (CategoriesRow catRow in Categories)
    		{
    			if (usableCat.Id == catRow.Id)
    			{
    				// Add categories that are used.
    				usedCategories.Add(usableCat);
    				// Will break the first loop.
    				break;
    			}
    		}
    	}
    	return usedCategories;
    }
