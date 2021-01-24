    public IHttpActionResult Get()
    {
      if(someErrorCondition)
         return Content(HttpStatusCode.BadRequest, JsonResult<string>.CreateResponse("Ciao Mondo!"));
      return Ok(JsonResult<string>.CreateResponse("Ciao Mondo!"));
    }
