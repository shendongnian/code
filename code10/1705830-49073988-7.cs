    [Route("api/Player/videos")]
    public IHttpActionResult GetVideoMappings()
    {
        var model = new MyCarModel();
        return Ok(model);    
    }
