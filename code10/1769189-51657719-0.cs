    public void CreateIndexIfNotExists()
	{
		var indexState = new IndexState();
		if (!client.IndexExists(IndexName).Exists)
			client.CreateIndex(IndexName, descriptor =>
				descriptor.Index(IndexName)
					.InitializeUsing(indexState)
					.Settings(SetupAnalysis)
					.Mappings(ms => ms
						.Map<Entity>(m => m.AutoMap())
					)
			);
	}
