    public IEnumerable<SelectListItem> GetClassifiedCategories(IEnumerable<ClassifiedCategory> categories, string selectedCategoryName)
    {
    	var list=new List<SelectListItem>();
    
    	foreach (var cat in categories)
    	{
    		var item = new SelectListItem()
    					   {
    						   Text = cat.Name,
    						   Value = cat.Id
    						};
    		if (cat.Name==selectedCategoryName)
    			item.Selected = true;
    		list.Add(cat);
    	}
    	return list;
    }
