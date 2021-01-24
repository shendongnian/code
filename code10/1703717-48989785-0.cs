    [HttpGet]
    [Route("SystemInfo")] // That's the name of the route you will call
    public IHttpActionResult SystemInfo()
    {
        return Ok();
    }
