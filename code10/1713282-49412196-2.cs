    HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
    result.Content = new StreamContent(ms);
    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "Tables.zip" };
    return result;
