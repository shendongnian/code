    using (var server = TestServer.Create<Startup>())
    {
        var result = await server.HttpClient.GetAsync("api/book");
        string responseContent = await result.Content.ReadAsStringAsync();
        var entity = JsonConvert.DeserializeObject<List<string>>(responseContent);
    }
