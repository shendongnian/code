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
                var bytes = await result.Content.ReadAsByteArrayAsync();
                return new FileResponse(bytes, "audio/wav", "your-file-name.wav");
            }
        }
    }
