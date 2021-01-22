    ProjectItem GetFiles(ProjectItem item)
    {
    	//base case
    	if (item.ProjectItems == null)
    		return item;
    
    	var items = item.ProjectItems.GetEnumerator();
    	while (items.MoveNext())
    	{
    		var currentItem = (ProjectItem)items.Current;
    		projectItems.Add(GetFiles(currentItem));
    	}
    
    	return item;
    }
