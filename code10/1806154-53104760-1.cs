    public T ExecuteGet<T>(string endpoint)
    {
        var uri = $"https://apiurl.company.com/api/v1/{endpoint}";
        using (HttpClient client = new HttpClient())
        {
            var x = client.GetAsync(uri);
            var result = x.Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(
                result, 
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }
                );
        }
    }
