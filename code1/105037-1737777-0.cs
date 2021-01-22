    public class ConnectionStringManager
    {
    	public string GeoDataConnectionString
    	{
    		get
    		{
    			return x 
    				? ConfigurationManager.ConnectionString["LIVEGeoDataConnection"])
    				: ConfigurationManager.ConnectionString["STAGINGGeoDataConnection"]);
    		}
    	}
    }
