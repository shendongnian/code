    public interface IMyProjectDataSource
    {
    	IEnumerable<string> GetUserNames();
    	void AddUser(string userName);
    }
    
    public class SqlServerMyProjectDataSource : IMyProjectDataSource
    {
    	public SqlServerMyProjectDataSource(string connectionString)
    	{
    		//...
    	}
    
    	public IEnumerable<string> GetUserNames()
    	{
    		//...
    	}
    
    	public void AddUser(string userName)
    	{
    		//...
    	}
    }
    
    public class PostgreSqlMyProjectDataSource : IMyProjectDataSource
    {
    
    	public IEnumerable<string> GetUserNames()
    	{
    		//...
    	}
    
    	public void AddUser(string userName)
    	{
    		//...
    	}
    }
    
    public class HttpCacheSqlMyProjectDataSource : IMyProjectDataSource
    {
    	public HttpCacheSqlMyProjectDataSource(IMyProjectDataSource parentMyProjectDataSource)
    	{
    
    	}
    
    	public IEnumerable<string> GetUserNames()
    	{
    		//...
    	}
    
    	public void AddUser(string userName)
    	{
    		//...
    	}
    }
