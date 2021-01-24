    using (var client = new HttpClient())
    {
        var method = string.Format("{0}{1}", ApiUrl, urlPart);
        client.BaseAddress = new Uri(ApiUrl);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
    
        HttpResponseMessage response = client.GetAsync(method).GetAwaiter().GetResult();
    
        if (response.IsSuccessStatusCode)
        {
            var data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
    
    
            return data;
        }
    
        return default(T);
    }
