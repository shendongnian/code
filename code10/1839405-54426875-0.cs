    interface IARepository 
    { 
    	IConnection Connection { set; }
    }
    
    class ARepository : IARepository
    {
    	public IConnection Connection { private get; set; }
    	
    	public ARepository(IService1 svc1, IService2 svc2)
    	{ /* ... */ }
    }
    
    
    class RepositoryFactory : IRepositoryFactory
    {
    	private IConnection Create<TRepository>(IConnection conn) 
            where TRepository : IARepository
    	{
    		var svc = _serviceProvider.GetService<TRepository>();
    		svc.Connection = conn;
    		return svc;
    	}
    }
