    COMAdminCatalogCollection applications;
    COMAdminCatalog catalog;
    
    catalog = new COMAdminCatalog();
    applications = (COMAdminCatalogCollection)catalog.GetCollection("Applications");
    applications.Populate();
    
    foreach(COMAdminCatalogObject application in applications)
    {
    	//do something with the application
    	if(  application.Name.Equals("MyAppName") )
    	{
    		COMAdminCatalogCollection components;
    		components = applications.GetCollection("Components", application.Key)
    		
    		foreach(COMAdminCatalogObject component in components)
    		{
    			// do something with component
    		}
    	}
    
    }
