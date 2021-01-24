    static ViewModelLocator()
    {
    	ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
    
    	if (ViewModelBase.IsInDesignModeStatic)
    	{
    		SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
    		SimpleIoc.Default.Register<IUnitOfWork, UnitOfWork>();
    	}
    	else
    	{
    		SimpleIoc.Default.Register<IDataService, DataService>();
    		SimpleIoc.Default.Register<IUnitOfWork, UnitOfWork>();
    	}
    	SimpleIoc.Default.Register<LoginViewModel>();
    
    	// Missing something like this (not sure what interface it implements...)
    	SimpleIoc.Default.Register<IConfiguratorContext, BomConfiguratorContext>();
    }
