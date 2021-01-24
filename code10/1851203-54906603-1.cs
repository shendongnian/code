    Vehicle fields = new Vehicle ();
    
    //create a terms query
    var query = new TermsQuery
    {
        IsVerbatim = true,
        Field = "VehicleOwnerId",
        Terms = new string[] { "30" },
    };
    
    string[] Fields = new[]
    {
        nameof(fields.Year),
        nameof(fields.MakeId),
        nameof(fields.ModelId)
    };
    
    var aggregations = new Dictionary<string, IAggregationContainer>();
    foreach (string sField in Fields)
    {
        var termsAggregation = new TermsAggregation(sField)
        {
            Field = sField
        };
    
        aggregations.Add(sField, new AggregationContainer { Terms = termsAggregation });
    }
    
    //create the search request
    var searchRequest = new SearchRequest
    {
        Query = query,
        From = 0,
        Size = 10,
        Aggregations = aggregations
    };
    
    var result = client.SearchAsync<InventoryLiveView>(searchRequest).Result;
    
    var years = result.Aggregations.Terms(nameof(fields.Year));
    Dictionary<string, long> yearCounts = new Dictionary<string, long>();
    foreach (var item in years.Buckets)
    {
        yearCounts.Add(item.Key, item.DocCount ?? 0);
    }
