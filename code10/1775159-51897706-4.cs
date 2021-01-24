    [HttpGet]
    public async Task<HttpResponseMessage> GetAudioAsync(
        string id)
    {
        var url = "http://localhost:8000/api/ExternalApi";
        using (var httpClientHandler = new HttpClientHandler())
        {
            httpClientHandler.UseDefaultCredentials = true;                
            using (var client = new HttpClient(httpClientHandler))
            {
                var result = await client.GetAsync(url);
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                var bytes = await result.Content.ReadAsByteArrayAsync();
                response.Content = new ByteArrayContent(bytes);
                response.Content.Headers.ContentLength = bytes.LongLength;
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                response.Content.Headers.ContentDisposition.FileName = "audio.wav";
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("audio/wav");
                return response;
            }
        }
    }
