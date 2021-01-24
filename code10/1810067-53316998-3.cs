	MyLazy _SubEvents = new MyLazy();
	public SubEventCollection SubEvents => _SubEvents.Get(LoadSubEvents);
	private SubEventCollection LoadSubEvents()
	{
		using ( var stream = new MemoryStream(DbSubEventsBucket) )
		{
			var sub_event_collection = Serializer.Deserialize<SubEventCollection>(stream);
			sub_event_collection.Initialize(this);
			return sub_event_collection;
		}
	}
