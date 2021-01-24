    public IHttpActionResult GET([FromUri] RequestQueryListDTO objAPIRequest)
    {
        var objResponse = new Response();
        
    	//check the properties of objAPIRequest
    	if(bad)
    	{
    		//add stuff if you want
    		return Content<Response>(HttpStatusCode.BadRequest, objResponse);
    	}
    	
    	//Business Access Layer Logic calling
        //-----------------------
    	ProductBAL objProductBAL = new ProductBAL();
    	
    	//you need to change this to async
    	var productDetails = objProductBAL.GetProductDetails(objAPIRequest);
    	//-----------------------
    	return Ok(objResponse);
    }
