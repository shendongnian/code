    public System.IO.Stream GetImage(string personID)
    {
        // parse personID, call DB
        OutgoingWebResponseContext context = WebOperationContext.Current.OutgoingResponse;
        
        if (image_not_found_in_DB)
        {
            context.StatusCode = System.Net.HttpStatusCode.Redirect;
            context.Headers.Add(System.Net.HttpResponseHeader.Location, url_of_a_default_image);
            return null;
        }
        // everything is OK, so send image
        context.Headers.Add(System.Net.HttpResponseHeader.CacheControl, "public");
        context.ContentType = "image/jpeg";
        context.LastModified = date_image_was_stored_in_database;
        context.StatusCode = System.Net.HttpStatusCode.OK;
        return new System.IO.MemoryStream(buffer_containing_jpeg_image_from_database);
    }
