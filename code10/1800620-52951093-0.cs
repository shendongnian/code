    [Route("{id}/file", Name = "GetContentFile")]
    [HttpGet]
    public async Task<IHttpActionResult> GetContentFile(string id)
    {
        ...
    	var result = await otcrepo.GetContentFile(id);
    	ret.Content = new StreamContent(result.stream);
    	ret.Content.Headers.ContentType = new MediaTypeHeaderValue(result.contentType);
        ...
    }
    
    public async Task<(Stream stream, string contentType)> GetContentFile(string id)
    {
    	var htc = new HttpClient()
    	var response = await htc.GetAsync(ConfigurationManager.AppSettings["BaseUrl"] + "/api/v2/nodes/" + id + "/content/");
    
    	var stream = await response.Content.ReadAsStreamAsync();
    	var contentType = response.Content.Headers.GetValues("Content-Type").FirstOrDefault();
    	return (stream, contentType);
    }
