    public  async Task<string> InfoAnswerAsync(WebRequest request)
     { 
    using (var response = await request.GetResponseAsync())
    {
        using (var stream = response.GetResponseStream())
            if (stream != null)
                using (var reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
    }
