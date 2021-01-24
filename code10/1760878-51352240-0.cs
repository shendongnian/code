    var cfg = new IgniteClientConfiguration { Host = "127.0.0.1" };
    using (var client = Ignition.StartClient(cfg))
    {
    	// Create cache for demo purpose.
    	var fooCache = client.GetOrCreateCache<int, object>("thin-client-test").WithKeepBinary<int, IBinaryObject>();
    	fooCache[1] = client.GetBinary().GetBuilder("foo")
    		.SetStringField("Name", "John")
    		.SetTimestampField("Birthday", new DateTime(2001, 5, 15).ToUniversalTime())
    		.Build();
    
    	var cacheNames = client.GetCacheNames();
    	"Diplaying first 5 items from each cache:".Dump();
    	
    	foreach (var name in cacheNames)
    	{
    		var cache = client.GetCache<object, object>(name).WithKeepBinary<object, object>();
    		var items = cache.Query(new ScanQuery<object, object>()).Take(5)
    			.ToDictionary(x => x.Key.ToString(), x => x.Value.ToString());
    		
    		items.Dump(name);
    	}
    }
    ```
