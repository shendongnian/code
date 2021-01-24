    private static void Main()
    {
        var defaultIndex = "documents";
    	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    
        var settings = new ConnectionSettings(pool)
            .DefaultIndex(defaultIndex)
    		.DefaultTypeName("_doc");
    
        var client = new ElasticClient(settings);
    	
    	if (client.IndexExists(defaultIndex).Exists)
    		client.DeleteIndex(defaultIndex);
    
    	client.Bulk(b => b
    		.IndexMany<object>(new[] {
    			new { Message = "hello" },
    			new { Message = "world" }
    		})
    		.Refresh(Refresh.WaitFor)
    	);
    	
    	var searchResponse = client.Search<object>(new SearchRequest<object>
    	{
    		From = 0 * 100,
    		Size = 100,
    		FilterPath = new [] { "hits.hits._id" },
    		Query = new QueryStringQuery
    		{
    			Query = ""
    		}
    	});
    	
    	foreach(var id in searchResponse.Hits.Select(h => h.Id))
    	{
    		// do something with the ids
    		Console.WriteLine(id);
    	}
    }
