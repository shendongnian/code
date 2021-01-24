    [HttpPost]
    public async Task<IActionResult> Submit([FromBody]SubmitModel model)
    { 
       // this endpoint returns a 400 bad request
       return Ok();
    }
 
