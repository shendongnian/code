    private const string RoutePrefix = "products";
    [Route(RoutePrefix + "/list")]
    public IActionResult Index()
    {
        ...
    }
