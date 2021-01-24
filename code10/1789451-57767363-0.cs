    public async Task<HttpResponseMessage> CreateAuthorization(string url, string username, string password)
    {
        HttpResponseMessage response;
    
        using (var httpClient = new HttpClient())
        {
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), url))
            {
                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                var authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                request.Headers.TryAddWithoutValidation("Authorization", $"Basic {authorization}");
                response = await httpClient.SendAsync(request);
            }
        }
    
        return response;
    }
