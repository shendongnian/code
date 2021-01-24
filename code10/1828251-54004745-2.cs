    status HttpClient client = new HttpClient();
    public async Task<int> CreateUser(UserDto dto) {
        string endpoint = ApiQuery.BuildAddress(Endpoints.Users);
        var json = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
        
        var postResponse = await client.PostAsync(endpoint, json);
        var location = postResponse.Headers.Location;// api/users/{id here}
        var id = await postResponse.Content.ReadAsAsync<int>();
        return id;
    }
    
