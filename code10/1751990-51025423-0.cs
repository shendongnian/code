    public static async Task<OcspHttpRequest> ToOcspHttpRequest(this HttpRequestMessage requestMessage)
    {
        var httpRequestBase = new OcspHttpRequest
        {
           HttpMethod = requestMessage.Method.Method,
           MediaType = requestMessage.Content.Headers.ContentType.MediaType,
           RequestUri = requestMessage.RequestUri,
           Content = await requestMessage.Content.ReadAsByteArrayAsync()
         };
         return httpRequestBase;
     }
