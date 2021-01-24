	if (client.IndexExists(defaultIndex).Exists)
		client.DeleteIndex(defaultIndex);
    
	var createIndexResponse = client.CreateIndex(defaultIndex, c => c 
		.Mappings(m => m
			.Map<DataEntity>(mm => mm
				.AutoMap()
				.Properties(p => p
					.GeoPoint(g => g
						.Name(n => n.Location)
					)
				)
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
