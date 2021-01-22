    public partial class DashboardEntities : ObjectContext, IUnitOfWork
    {
    	public const string ConnectionString = "name=DashboardEntities";
    	public const string ContainerName = "DashboardEntities";
    
    	public DashboardEntities()
    		: base(ConnectionString, ContainerName)
    	{
    		this.ContextOptions.LazyLoadingEnabled = true;
    	}
    	
    	...
    }
