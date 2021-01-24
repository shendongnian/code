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
    		.Mappings(m => m
                .Map<Tweet>(mm => mm
                    .AutoMap()
                )
            )
    	);
    
        var bulkResponse = client.Bulk(b => b
            .IndexMany(new []
            {
                new Tweet 
                { 
                    id = 1, 
                    text = "foo",
                    hashtags = new List<hashtags>
                    { 
                        new hashtags { hashtext = "aaaa" },
                        new hashtags { hashtext = "bbbb" },
                        new hashtags { hashtext = "cccc" }
                    }
                }, 
                new Tweet
                {
                    id = 2,
                    text = "bar",
                    hashtags = new List<hashtags>
                    {
                        new hashtags { hashtext = "aaaa" },
                        new hashtags { hashtext = "bbbb" }
                    }
                },
                new Tweet
                {
                    id = 3,
                    text = "baz",
                    hashtags = new List<hashtags>
                    {
                        new hashtags { hashtext = "aaaa" },
                        new hashtags { hashtext = "cccc" }
                    }
                }
            })
            .Refresh(Refresh.WaitFor)
        );
    
        var searchResponse = client.Search<Tweet>(s => s
            .Size(0)
            .Aggregations(childAggs => childAggs
                    .Nested("hashtags", n => n
                        .Path(p => p.hashtags)
                        .Aggregations(nestedAggs => nestedAggs
                            .Terms("by_tags", t => t
                                .Field(f => f.hashtags.First().hashtext)
                            )
                        )
                    )
                )
            );
            
        var hashtagBuckets = searchResponse.Aggregations.Nested("hashtags").Terms("by_tags").Buckets;
            
        foreach(var bucket in hashtagBuckets)
        {
            Console.WriteLine($"{bucket.Key}\t{bucket.DocCount} times");
        }
    }
    
    public class Tweet
    {
        public ulong id { get; set; }
        public string text { get; set; }
        [Nested]
        public List<hashtags> hashtags { get; set; }
    }
    
    
    public class hashtags
    {
        [Keyword]
        public string hashtext { get; set; }
    }
