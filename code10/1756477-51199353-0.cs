    [HttpGet]
    [AuthorizeWebApi]
    [Route("downloadZip")]
    public async Task<IHttpActionResult> downloadZipFile(){
        try{
    	//Using WS reference
            using(ServiceLayer services = new ServiceLayer()){
                
    	    //Catch the byte array
    	    arr = services.getByteArray();
    	       
    	    //Encode in base64 string
    	    string base64String = System.Convert.ToBase64String(arr, 0, arr.length);	
    
     	    //Build the http response		
                var result = new HttpResponseMensage(HttpStatusCode.OK){
                    Content = new StringContent(base64String); }
    
                result.Content.Headers.ContentDisposition 
                   = new ContentDispostionHeaderValue("attachment"){
                    FileName = "zip-dowload.zip" };
    
                result.Content.Headers.ContentType 
                   = new MediaTypeHeaderValue("application/octec-stream");
    
                var response = ResponseMessage(result);
                return result;
            }
        }cacth(Exception ex){ /*Do something*/ }
    }
