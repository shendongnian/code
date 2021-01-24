    public async Task<T> GetJson<T>(string url)
    {
        using (var client = new System.Net.Http.HttpClient())
        {
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
    
            return (T)JsonConvert.DeserializeObject<T>(json);
        }
    }
