    [HttpGet()]
    public ActionResult<string> Get([FromQuery] ValueModel value)
    {
        return new OkObjectResult($"MinX={value.MinX}; MinY={value.MinY}");
    }
    [HttpPost]
    public ActionResult Post([FromQuery]ValueModel value)
    {
        return new OkObjectResult($"MinX={value.MinX}; MinY={value.MinY}");
    }
