    class SMSearchCriteria
    {
            public SMKeywords keywords { get; set; }
            public SMDates dates { get; set; }
            public SMClusters clusters { get; set; }
            public SMTaxominies taxonomies { get; set; }
            public SMSort sort { get; set; }
    }
    
    class SMTaxominies
    {
    	public Dictionary<string, string> Topics;
    	public Keywords<string, string> Keywords;
    }
