    [HttpPost]
    [Route("api/test")]
    public async Task<HttpResponseMessage> TestMethod(HttpRequestMessage request)
    {
        string root = HttpContext.Current.Server.MapPath("~/App_Data");
        var provider = new MultipartFormDataStreamProvider(root);
        await Request.Content.ReadAsMultipartAsync(provider);
        var testValue = provider.FormData.GetValues("test")[0];
        return Request.CreateResponse(HttpStatusCode.OK);
    }
