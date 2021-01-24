    public sealed class GeoLocationEntity
    {
    	public GeoLocationEntity(
    		double latitude,
    		double longitude)
    	{
    		this.Latitude = latitude;
    		this.Longitude = longitude;
    	}
    
    	[PropertyName("lat")]
    	public double Latitude { get; }
    
    	[PropertyName("lon")]
    	public double Longitude { get; }
    }
    
    public sealed class DataEntity
    {
    	public DataEntity(
    		GeoLocationEntity location)
    	{
    		this.Location = location;
    	}
    
    	[PropertyName("location")]
    	public GeoLocationEntity Location { get; }
    }
