    public abstract class BaseDataService
    {
    	private Database database = null;
    
    	public BaseDataService()
    	{
    		DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection), false);
    		this.database = DatabaseFactory.CreateDatabase("_connection");
    	}
    	public Database SqlDatabase
    	{
    		get
    		{
    			return this.database;
    		}
    
    		set
    		{
    			this.database = value;
    		}
    	}
    }
