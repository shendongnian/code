    var projects = myProjects.GetEnumerator();
    while (projects.MoveNext())
    {
    	var items = ((Project)projects.Current).ProjectItems.GetEnumerator();
    	while (items.MoveNext())
    	{
    		var item = (ProjectItem)items.Current;
            //Recursion to get all ProjectItems
    		projectItems.Add(GetFiles(item));
    	}
    }
