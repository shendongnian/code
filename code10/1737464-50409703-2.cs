    using (HttpClient client = GetClient())
    {
        var obj = new { uid = someGuid.ToString()) };
    	var json = JsonConvert.SerializeObject(obj);
    	var content = new StringContent(json, Encoding.UTF8, "application/json");
    	var result = client.PostAsync(path, content).Result;
    
        return response.Content.ReadAsAsync<T>().Result;
    }
