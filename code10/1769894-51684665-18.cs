    [HttpPost]
    [Route("api/test")]
    public HttpResponseMessage TestMethod(HttpRequestMessage request)
    {
        var testValue = HttpContext.Current.Request.Form["test"];
    
        return Request.CreateResponse(HttpStatusCode.OK, testValue);
    }
