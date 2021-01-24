    public async Task<T> GetObjectFromContent<T>(HttpContent content) where T: class
    {
        string response = await content.ReadAsStringAsync();
        if (string.IsNullOrWhiteSpace(response))
            return null;
        try
        {
            T obj = JsonConvert.DeserializeObject<T>(response);
            return obj;
        }
        catch(JsonSerializationException)
        {
            return null;
        }          
    }
