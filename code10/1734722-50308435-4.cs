    [HttpPost]
    [Route("users/verifyLoginCredentials")]
    public IHttpActionResult VerifyLoginCredentials([FromBody]LoginModel model)
    {
       //validate your model    
       if ( model == null || !ModelState.IsValid )     
       {
           return BadRequest();
       }
    
       //stuff
       return Ok();
    }
