    var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    var settings = new ConnectionSettings(pool)
        .DefaultMappingFor<MyDocument>(m => m
            .IndexName("test_index")
            .TypeName("doc")
        );
    var client = new ElasticClient(settings);
    
    var searchResponse = client.Search<MyDocument>();
    
    // A collection of the top 10 matching documents
    var documents = searchResponse.Documents;
