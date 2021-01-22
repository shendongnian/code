    public class Blah(ConnectionStringManager connManager)
    {
    	public void Do()
    	{
    		var geoData = new GeoData { ConnectionString = connManager.GeoDataConnectionString };
    		geoData.GetCountries();
    	}
    }
