    public sealed class DataEntity
    {
    	public DataEntity(
    		GeoLocation location)
    	{
    		this.Location = location;
    	}
    
    	[DataMember(Name = "location")]
    	public GeoLocation Location { get; }
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
		new DataEntity(new GeoLocation(88.59, -98.87)), 
		i => i.Refresh(Refresh.WaitFor)
	);
		
	var searchResponse = client.Search<DataEntity>(s => s
		.Query(q => q
			.MatchAll()
		)
	);
