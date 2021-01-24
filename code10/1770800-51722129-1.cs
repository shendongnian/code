    [HttpGet]
    public HttpResponseMessage GetDownloadableFIle(string name)
    {
        try
        {
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            var filePath = $"{MyRootPath}/{name}";
            var bytes = File.ReadAllBytes(filePath );
            result.Content = new ByteArrayContent(bytes);
            var mediaType = "application/octet-stream";
            result.Content.Headers.ContentType = new  System.Net.Http.Headers.MediaTypeHeaderValue(mediaType);
            return result;
        }
        catch (Exception ex)
        {
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.ToString()));
        }
    }        
