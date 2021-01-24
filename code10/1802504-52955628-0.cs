    /// <summary>
    /// Common, shared query options
    /// </summary>
    public CommonQueryOptions() {
        Fields = new List<string>();
        FilterQueries = new List<ISolrQuery>();
        Facet = new FacetParameters();
        ExtraParams = new Dictionary<string, string>();
    }
    /// <summary>
    /// Fields to retrieve.
    /// By default, all stored fields are returned
    /// </summary>
    public ICollection<string> Fields { get; set; }
