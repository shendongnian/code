    public async Task<IEnumerable<T>> GetEntitiesAsync() {
       var request = new RestRequest("somePath");
       request.AddParameter("Test", "OK");
       return await _client.GetAsync<List<T>>(request);       
    }
