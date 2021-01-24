    [Route("api/listing/attachment")]
    [HttpGet]
    public async Task<IHttpActionResult> GetAttachmentAsync(string fileName)
    {
        var attachment = await _repository.GetAttachmentAsync(fileName);
        var removePath = fileName.Substring(fileName.IndexOf("/", fileName.IndexOf("/", StringComparison.Ordinal) + 1, StringComparison.Ordinal) + 1);
        var result = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new ByteArrayContent(attachment)
        };
        result.Content.Headers.ContentDisposition =
            new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
        {
            FileName = removePath
        };
        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        
        return result;
    }
