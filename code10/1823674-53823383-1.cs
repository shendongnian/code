    [HttpGet]
    public IHttpActionResult GetData()
    {
        var result = (new PersonDataAccess ()).GetData();
        
        return Ok(result);
    }
