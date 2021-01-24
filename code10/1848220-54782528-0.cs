    public static async Task<string> GetData(API api, string id)
    {
        HttpResponseMessage response = await 
        api.Instance.GetAsync(string.Format(requestURL, id));
        response.EnsureSuccessStatusCode();
    
        // return URI of the created resource.
        return await response.Content.ReadAsStringAsync();
    }
