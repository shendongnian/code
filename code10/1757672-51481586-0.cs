    HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
    httpResponseMessage.Content = new ByteArrayContent(data.ToArray());
    httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
    httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
    httpResponseMessage.Content.Headers.ContentDisposition.FileName = fileName;
    httpResponseMessage.StatusCode = HttpStatusCode.OK;
    return httpResponseMessage;
