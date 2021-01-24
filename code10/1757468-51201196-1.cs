    var elasticClient = new ElasticClient(settings);
    var scriptParams = new Dictionary<string, object>
    {
    	{"Title", "New Title"},
    	{"Desc", "New Desc"}
    };
    var response = elasticClient
	    .UpdateByQuery<dynamic>(q => q.Query(rq => rq.Term(....))
	    .Script(script =>
		    script.Inline(
				$"ctx._source.Title = params.Title;" +
				$"ctx._source.Desc  = params.Desc ;"
			)
	    .Params(scriptParams));
