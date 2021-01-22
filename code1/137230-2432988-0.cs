    System.Data.DataTable table = VisibleServerList.GetVisibleServers();
    
    public static class VisibleServerList
    {
    	public static System.Data.DataTable GetVisibleServers()
    	{
    		System.Data.Sql.SqlDataSourceEnumerator instance = System.Data.Sql.SqlDataSourceEnumerator.Instance;
    		return instance.GetDataSources();
    	}
    }
