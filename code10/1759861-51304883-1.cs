	public class DataAccess : IDataAccess
	{
	    private IConfiguration _config;
	    public DataAccess(IConfiguration config)
	    {
	        _config = config;
	    }
	    public void Method()
	    {
	        var connectionString = _config.GetValue<string>("App:Connection:Value"); //notice the structure of this string
	        //do whatever with connection string
	    }
	}
