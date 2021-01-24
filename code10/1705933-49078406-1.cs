    // GET api/solarplants/active
    [HttpGet("Active")]
    public IHttpActionResult Active()
    { ... }
    //GET api/solarplants?name=name
    [HttGet]
    public HttpResponseMessage GetByName([FromQuery]string name)
    { ... }
