    [HttpPost]
    [Route("api/image")]
    public async Task<IHttpActionResult> InsertNewMerchant()
    {
    		// your form data is here
    			 var formData = HttpContext.Current.Request.Form;
    			 HttpFileCollection files = HttpContext.Current.Request.Files;
    			 
    		
                if (files.Count == 1)
                {
    			// this is the file you need 
                    var image = files[0];
    					// do something with the file
    		    }
        return StatusCode(System.Net.HttpStatusCode.Created);
    }
     
