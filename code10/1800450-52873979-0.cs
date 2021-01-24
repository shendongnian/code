    [HttpPost]
    [Route("AddValue")]
    public IHttpActionResult AddValue([FromBody]MiddleDTO param)
    {
        if (param == null)
        {
    	    return InternalServerError(new Exception("param is null"));
        }
    
        return OK(param);
    }
