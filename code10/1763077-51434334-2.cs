    [HttpGet]
    [Route("Bar/Create/{aid}", Name = "FooBarRouteName")] // GET Bar/Create/abc123
    public ActionResult Create(string aid) {
        if (string.IsNullOrWhiteSpace(aid)) {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        ...
    }
    
    [HttpPost]
    [Route("Bar/Create/{aid}")] // POST Bar/Create/abc123
    public ActionResult Create(string aid, Foo viewModel) {
        if (string.IsNullOrWhiteSpace(aid)) {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        ...
    }
