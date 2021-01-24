    [HttpPost]
    [Route("SaveWorkingTime")]
    public IHttpActionResult SaveWorkingTime([FromBody] TimeLog time)
    {
        // Perform saving
        return Ok(time);
    }
