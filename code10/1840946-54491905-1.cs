    private static void Main()
    {
        var defaultIndex = "students";
        var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    
        var settings = new ConnectionSettings(pool)
            .DefaultIndex(defaultIndex);
    
        var client = new ElasticClient(settings);
    	
    	if (client.IndexExists(defaultIndex).Exists)
    		client.DeleteIndex(defaultIndex);
    	
    	var createIndexResponse = client.CreateIndex(defaultIndex, c => c
    		.Settings(s => s
    			.NumberOfShards(1)
    			.NumberOfReplicas(0)
    		)
    		.Mappings(m => m
    			.Map<Student>(mm => mm
    				.AutoMap()
    			)
    		)
    	);
    	
    	var students = Enumerable.Range(1, 20).Select(i =>
    		new Student 
    		{
    			Id = i,
    			Name = i % 2 == 0 ? "Foo" : "Bar",
    			Grade = i
    		}
    	);
    	
    	var bulkResponse = client.Bulk(b => b
    		.IndexMany(students)
    		.Refresh(Refresh.WaitFor) // refresh, so that documents indexed are available to search immediately
    	);
        
    	var topX = 10;
    	
    	var searchResponse = client.Search<Student>(s => s
    		.Aggregations(a => a
    			.Terms("student_name", t => t
    				.Field(f => f.Name.Suffix("keyword"))
    				.Aggregations(aa => aa
    					.TopHits("top_grades", th => th
    						.Sort(so => so
    							.Descending(f => f.Grade)
    						)
    						.Size(topX)
    					)
    				)
    			)
    		)
    	);
    	
    	var studentNames = searchResponse.Aggregations.Terms("student_name");
        
    	foreach(var bucket in studentNames.Buckets)
    	{
    		var header = $"Student Name: {bucket.Key}";
    		Console.WriteLine(header);
    		Console.WriteLine(new string('-', header.Length));
    		foreach(var hit in bucket.TopHits("top_grades").Documents<Student>())
    		{
    			Console.WriteLine($"Id: {hit.Id}, Grade: {hit.Grade}");
    		}
    		Console.WriteLine();
    	}
    }
