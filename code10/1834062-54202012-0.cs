    public async Task GetResource()
    {
        CRUDService(); // <<<<---- this was added <<<<----
        var response = await _httpClient.GetAsync("/v1/song/latest");
        response.EnsureSuccessStatusCode();
    
        var content = await response.Content.ReadAsStringAsync();
        var movies = new List<Movie>();
    
        if (response.Content.Headers.ContentType.MediaType == "application/json")
        {
            movies = JsonConvert.DeserializeObject<List<Movie>>(content);
        }
    }
