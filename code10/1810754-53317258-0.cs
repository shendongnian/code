    var client = new ElasticClient(settings);
    var request = new 
    {
        AddDateFilter = true
    };
    var boolQuery = new BoolQueryDescriptor<AttractionDocument>();
    boolQuery.Must(
        // mn => AddRegionQuery(permissions, mn),
        // mn => AddOffersQuery(permissions, mn),
        mn => request.AddDateFilter ? mn.DateRange(d => d.Field(f => f.AvailableFrom).LessThanOrEquals(DateTime.Now)) : mn,
        mn => request.AddDateFilter ? (mn.Exists(d => d.Field(f => f.AvailableTo)) &&
                                      mn.DateRange(d => d.Field(f => f.AvailableTo).GreaterThanOrEquals(DateTime.Now))) ||
                                      !mn.Exists(d => d.Field(f => f.AvailableTo)) : mn //,
        // mn => AddGenresQuery(genres, mn)
    );
    client.Search<AttractionDocument>(s => s
        .Query(q => q.Bool(b => boolQuery))
    );
