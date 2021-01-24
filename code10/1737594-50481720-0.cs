    private static void Main()
    {
        var defaultIndex = "topics";
    	var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    
        var settings = new ConnectionSettings(pool)
            .DefaultIndex(defaultIndex);
    
        var client = new ElasticClient(settings);
        
        if (client.IndexExists(defaultIndex).Exists)
            client.DeleteIndex(defaultIndex);
            
        client.CreateIndex(defaultIndex, c => c
    		.Mappings(m => m
    			.Map<Topic>(mm => mm
    				.AutoMap()
    			)
    		)
    	);
        
        var documents = Enumerable.Range(1, 10)
    		.Select(i => new Topic
    		{
    			Status = i == 1 ? EnumStatus.Disabled : EnumStatus.Enabled,
    			KeywordValues = Enumerable.Range(1, 5)
    				.Select(j => new KeywordValue
    				{
    					KeywordId = $"keyword {i} {j}"
    				}).ToList()
    		});
    
        client.Bulk(b => b
            .IndexMany(documents, (d, document) => d
                .Document(document)
            )
            .Refresh(Refresh.WaitFor)
        );
    
    	client.Search<Topic>(s => s
    		.Size(0)
    		.Query(q => +q
    			.Term(t => t.Status, (int)EnumStatus.Enabled)
    		)
    		.Aggregations(ta => ta
    			.Nested("kv", n => n.Path(p => p.KeywordValues)
    				.Aggregations(aa => aa
    					.ValueCount("vc", v => v.Field(vf => vf.KeywordValues.First().KeywordId))))
    		)
    	);
    }
    
    [ElasticsearchType(Name = "Topic")]
    public class Topic
    {
    	[Number(NumberType.Integer, Coerce = true)]
    	public EnumStatus Status { get; set; }
    
    	[Nested]
    	public List<KeywordValue> KeywordValues { get; set; }
    
    }
    
    [ElasticsearchType(Name = "KeywordValue")]
    public class KeywordValue
    {
    	[Keyword]
    	public string KeywordId { get; set; }
    }
    
    public enum EnumStatus
    {
    	Enabled,
    	
    	Disabled
    }
