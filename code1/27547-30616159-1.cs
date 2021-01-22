    [HttpGet]
    // Returns
    public ActionResult Index()
    {
    	//.....
    }
    
    [HttpGet]
    [Route("View")]
    // Returns/View
    public ActionResult View()
    {
    	return View(7026);
    }
    
    [HttpGet]
    [Route("View/{id:int}")]
    // Returns/View/7003
    public ActionResult View(int id)
    {
    	//.....
    }
    
    [HttpGet]
    [Route("View/{id:Guid}")]
    // Returns/View/99300046-0ba4-47db-81bf-ba6e3ac3cf01
    public ActionResult View(Guid id)
    {
    	//.....
    }
