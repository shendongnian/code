    var mongoClient = new MongoClient(new MongoClientSettings
    {
    	Server = new MongoServerAddress("localhost", 27017),
    	ClusterConfigurator = cb =>
    	{
    		cb.Subscribe<CommandStartedEvent>(e =>
    		{
    			Console.WriteLine($"{e.CommandName} - {e.Command.ToJson(new JsonWriterSettings { Indent = true })}");
    			Console.WriteLine(new String('-', 32));
    		});
    	}
    });
