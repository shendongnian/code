    [UrlRoute(Path = "Forum")]
    public ActionResult Index()
    {
        ...
    }
    
    [UrlRoute(Path = "Forum/General-Discussion")]
    public ActionResult GeneralDiscussion()
    {
        ...
    }
    
    [UrlRoute(Path = "Forum/Technical-Support/Product/{productId}")]
    public ActionResult ProductDetails(string productId)
    {
        ...
    }
    
    [UrlRoute(Path = "Forum/Technical-Support/Website/{topicId}/{pageNum}")]
    [UrlRouteParameterDefault(Name = "pageNum", Value = "1")]
    public ActionResult SupportTopic(string topicId, int pageNum)
    {
        ...
    }
