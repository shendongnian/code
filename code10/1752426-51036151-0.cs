    QueryOptions options = new QueryOptions
    {
    	StartOrCursor = new StartOrCursor.Start(0),
    	Rows = 1,
    	Facet = new FacetParameters { Queries = new[] { new SolrFacetFieldQuery("Categories") } }
    };
    
    var result = _solrConnection.Query(new SolrQuery("*"), options);
    
    if (result.FacetFields.ContainsKey("Categories"))
    {
    	return result.FacetFields["Categories"]
    		.Where(li => li.Value > 0)
    		.Select(y=> y.Key)
    		.ToList();
    }
