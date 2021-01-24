    [HttpGet]
    public IHttpActionResult GetData(int id)
    {
        var result = (new PersonDataAccess ()).GetData(id);
        
        if (result == null)
            return NotFound();
        return Ok(result);
    }
