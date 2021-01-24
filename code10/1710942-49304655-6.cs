    public async Task<int> RegisterAsync(Model model)
    {
        var response = await YourHttpClient
           .SendAsync(new HttpRequestMessage(HttpMethod.Post, new Uri(BaseUri, "api/Foo/Faa"))
        {  
            Content = new StringContent(
               JsonConvert.SerializeObject(model),
               Encoding.UTF8, "application/json")
        });
        var result = await response.Content.ReadAsStringAsync();
        return 0;
    }
