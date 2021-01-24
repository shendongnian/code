    public sealed class GeoLocationEntity
    {
    	public GeoLocationEntity(
    		double latitude,
    		double longitude)
    	{
    		this.Latitude = latitude;
    		this.Longitude = longitude;
    	}
    
    	[JsonProperty("lat")]
    	public double Latitude { get; }
    
    	[JsonProperty("lon")]
    	public double Longitude { get; }
    }
    
    public sealed class DataEntity
    {
    	public DataEntity(
    		GeoLocationEntity location)
    	{
    		this.Location = location;
    	}
    
    	[JsonProperty("location")]
    	public GeoLocationEntity Location { get; }
    }
    // ---
	if (client.IndexExists(defaultIndex).Exists)
		client.DeleteIndex(defaultIndex);
    
	var createIndexResponse = client.CreateIndex(defaultIndex, c => c 
		.Mappings(m => m
			.Map<DataEntity>(mm => mm
				.AutoMap()
			)
		)
	);
	var indexResponse = client.Index(
		new DataEntity(new GeoLocationEntity(88.59, -98.87)), 
		i => i.Refresh(Refresh.WaitFor)
	);
		
	var searchResponse = client.Search<DataEntity>(s => s
		.Query(q => q
			.MatchAll()
		)
	);
