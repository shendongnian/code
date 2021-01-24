    //setting up your repositories
	var container = new Container();
	container.Configure(config =>
    {
        // Register stuff in container, using the StructureMap APIs...
        config.For<IDataRepository>().Add(new FileRepository("\\server\share\customers")).Named("customers");
        config.For<IDataRepository>().Add(new FileRepository("\\server\share\invoices")).Named("invoices");
        config.For<IDataRepository>().Add(new DatabaseRepository(new DbConnection(configurationString))).Named("persist");
        config.For<IDataRepository>().Use("persist"); // Optionally set a default
        config.Populate(services);
    });
	
	
	//then later when you need to use it...
	public DataStructure ImportCustomers(IContainer container)
    {
		var customerRepo = container.GetInstance<IDataRepository>("customers");
		return customerRepo.GetData();
	}
	
