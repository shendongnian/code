    [HttpPost]
    public async Task<IActionResult> Post([FromRoute]string tourId)
    {
    	var response = new ApiResponse();
    	if (Request.ContentType.Equals("image/jpeg"))
    	{
    		using (var stream = new MemoryStream())
    		{
    			await Request.Body.CopyToAsync(stream);
    			
                ...
    		}
    	}
    	else
    	{
    		...
    	}
    
    	return Ok(response);
    }
