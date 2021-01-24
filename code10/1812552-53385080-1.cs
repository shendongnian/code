    private void OnMenuSelected(object sender, SelectedItemChangedEventArgs e)
    {
    	if (item.Title == "Movies")
    	{
    		Type page = (MasterPageItem)e.SelectedItem.TargetType; 
    		//page is HomePage  
            var pageInstance = (HomePage)Activator.CreateInstance(page)
            pageInstance.MenuName = item.Title;
    		Detail = new NavigationPage(pageInstance);
    	}
    }
