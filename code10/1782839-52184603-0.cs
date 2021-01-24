       [HttpPost]
		public IActionResult Index([FromBody] personalInfo)
		{
            //check for multipart request
			if (MultipartRequestHelper.IsMultipartContentType(Request.ContentType))
             {                  
                  // request for uploaded files 
			      var file = Request.Form.Files[0];
             }
            
         }
