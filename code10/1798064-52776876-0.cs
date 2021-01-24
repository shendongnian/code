    private static void Main()
    {
        var defaultIndex = "my-index";
    	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    
        var settings = new ConnectionSettings(pool)
            .DefaultIndex(defaultIndex);
    
        var client = new ElasticClient(settings);
        
        var bulkAll = client.BulkAll(MyDocuments(), b => b
    		.Index(null)
    		.Type(null)
    		.BufferToBulk((bu, docs) =>
    		{
    			foreach (var doc in docs)
    			{
    				bu.Index<MyDocument>(bi => bi
    					.Index(doc.Id % 2 == 0 ? "even-index" : "odd-index")
    					.Document(doc)
    			   );
    			}
    		})
    		.RefreshOnCompleted()
    		.Size(100)
    	);
    
    	bulkAll.Wait(TimeSpan.FromMinutes(20), _ => {});
    }
    
    private static IEnumerable<MyDocument> MyDocuments()
    {
    	for (int i = 0; i < 1000; i++)
    		yield return new MyDocument(i);
    }
    
    
    public class MyDocument 
    {
    	public MyDocument(int id)
    	{
    		Id = id;
    		Message = $"message {id}";
    	}
    	
    	public int Id { get; set; }
    	
        public string Message { get; set; }
    }
