    [HttpGet]
    public string Get()
    {
        return "get-default";
    }
    
    [HttpGet]
    public string Get(int id)
    {
        return "get" + id;
    }
    
    [HttpGet]
    [Route("api/values/bywait/{id}")]
    public string ByWait(int id)
    {
        return "bywait";
    }
