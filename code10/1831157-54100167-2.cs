    private static void Main()
    {
        var defaultIndex = "my_index";
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
    			.Map<MyEntity>(mm => mm
                    .AutoMap()
                    .DynamicTemplates(dt => dt
                        .DynamicTemplate("MyDto", dtd => dtd
                            .PathMatch("someProperty.*.name")
                            .Mapping(dm => dm
                                .Keyword(k => k)
                            )
                        )
                    )
                    .Properties(p => p
                        .Object<Dictionary<string, MyDto>>(o => o
                            .Name(n => n.SomeProperty)
                        )
                    )
                )
    		)
    	);
        
        var indexResponse = client.Index(new MyEntity 
        {
            SomeProperty = new Dictionary<string, UserQuery.MyDto>
            {
                { "field_1", new MyDto { Name = "foo" } },
                { "field_2", new MyDto { Name = "bar" } }
            }
        }, i => i.Refresh(Refresh.WaitFor));
        
        var mappingResponse = client.GetMapping<MyEntity>();
    }
    
    public class MyEntity
    {
        public Dictionary<string, MyDto> SomeProperty { get; set; }
    }
    
    public class MyDto
    {
        public string Name { get; set; }
    }
