    public async Task<IHttpActionResult> UploadFile()
    {
              
        var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
    
        foreach (var stream in filesReadToProvider.Contents)
        {
            var fileBytes = await stream.ReadAsByteArrayAsync();
        }
    }
