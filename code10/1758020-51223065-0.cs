    //Create Sub Cat List 
    List<CategoryVM> catlist = (List<CategoryVM>)catServices.GetAll();
    List<SubCategoryVM> subCats = subCatServices.GetAll();
    
    for (int i = 0; i < catlist.Count(); i++)
    {
    	foreach (SubCategoryVM item in subCatById)
    	{
    		catlist[i].SubCategoryVM.AddRange(subCats.Where(x => x.Category_Id == catlist[i].Id));
    	}
    }
