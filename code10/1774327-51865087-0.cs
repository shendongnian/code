    [Put]
    [Route("api/{userId}")] 
    public IHttpActionResult UpdateUser(Guid userId, [FromBody] user)  
    {
         if (userId == null) 
         {
           var message = "Sorry, this is not a valid GUID";
           HttpError err = new HttpError(message);
           return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, err));
         }
    
        . . .
    }
