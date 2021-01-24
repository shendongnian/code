    [Route("configuration/id")
    public IHttpActionResult GetConfigByID([FromUri] string id)
    {
        Config config = GetConfig(id);
        return Ok(config);
    }
