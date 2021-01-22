    protected void Application_Start(object sender, EventArgs e)
    {
    	Application.GetContainer()
    		// presenters / controllers are per request                 
    		.RegisterType<IEmployeeController, EmployeeController>(new ContextLifetimeManager<IEmployeeController>())
    
    		//Data Providers are Per session                
    		.RegisterType<IEmployeeDataProvider, EmployeeDataProvider>(new SessionLifetimeManager<IEmployeeDataProvider>())
    
    		//Session Factory is life time
    		.RegisterType<INHibernateSessionManager, NHibernateSessionManager>(new ContainerControlledLifetimeManager());
    }
