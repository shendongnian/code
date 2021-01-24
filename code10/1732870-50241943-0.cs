    var isettings = new IndexSettings
    {
        Analysis = new Analysis
        {
            TokenFilters = new TokenFilters()
        }
    };
    SynonymTokenFilter synonymFilter = new SynonymTokenFilter
    {
        Format = SynonymFormat.Solr,
        SynonymsPath = "synonym.txt",
        Tokenizer = "whitespace",
    };
    isettings.Analysis.TokenFilters.Add("mysynonym", synonymFilter);
    isettings.NumberOfReplicas = 1;
    isettings.NumberOfShards = 2;
    IndexState indexConfig = new IndexState
    {
        Settings = isettings,
    };
    
    var client - new ElasticClient();
    client.CreateIndex(new CreateIndexRequest("index", indexConfig));
