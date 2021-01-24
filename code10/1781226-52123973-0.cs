    public async Task<HttpResponseMessage> PostFormData()
    {
        // Check if the request contains multipart/form-data.
        if( !this.Request.Content.IsMimeMultipartContent() )
        {
            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        }
        // Temporarily write the request to disk (if you use `MultipartMemoryStreamProvider` your risk crashing your server if a malicious user uploads a 2GB+ sized request)
        String root = this.Server.MapPath("~/App_Data");
        MultipartStreamProvider provider = new MultipartFormDataStreamProvider(root);
        try
        {
            // Read the form data and serialize it to disk for reading immediately afterwards:
            await this.Request.Content.ReadAsMultipartAsync( provider );
            // This illustrates how to get the names each part, but remember these are not necessarily files: they could be form fields, JSON blobs, etc
            foreach( MultipartFileData file in provider.FileData )
            {
                Trace.WriteLine( file.Headers.ContentDisposition.FileName );
                Trace.WriteLine( "Server file path: " + file.LocalFileName );
            }
            
            return this.Request.CreateResponse( HttpStatusCode.OK );
        }
        catch( System.Exception e )
        {
            return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
        }
    }
