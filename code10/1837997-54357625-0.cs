    var filters = new Dictionary<string, object>
    {
        { "Year", 2017 },
        { "CategoryId", 198 },
        { "IsPublished", true },
    }
    
    var query = new Query("Posts");
    
    foreach(var filter in filters)
    {
        query = query.Where(filter.Key, filter.Value);
    }
