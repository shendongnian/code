    [HttpPost]
    [Route("jobs/isrunning")]
    public IHttpActionResult IsJobRunning([FromBody]JobArguments jobArguments) {
       // some logic
       return Ok(true);
    }
    
