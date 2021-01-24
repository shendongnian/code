    [Route ("/abc/123")]
    [HttpGet]
    public HttpResponseMessage ControllerIdSite(int IdSite){
           //CODE . . .
           return Request.CreateResponse<int>(HttpStatusCode.OK, IdSite);  
    }
