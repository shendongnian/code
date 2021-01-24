    var client = new ElasticClient();
    
    var createIndexResponse = client.CreateIndex("percolation", c => c
        .Mappings(m => m
            .Map<SearchAgent>(mm => mm
                .AutoMap<SearchAgent>()
                .AutoMap<Item>()
            )
        )
    );
