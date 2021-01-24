    using (HttpClient httpClient = new HttpClient())
    {
        httpClient.Timeout = new TimeSpan(0, 2, 0);  // 2 minutes
        httpClient.DefaultRequestHeaders.Authorization = 
            new AuthenticationHeaderValue("Bearer", result.AccessToken);
