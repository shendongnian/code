    public class HttpCacheSqlMyProjectDataSource : IMyProjectDataSource
    {
    	public HttpCacheSqlMyProjectDataSource(IMyProjectDataSource parentMyProjectDataSource)
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
