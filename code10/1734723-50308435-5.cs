    var model = new LoginModel { Username = "abc", Password="abc" } ;
    using (var client = new HttpClient())
    {               
        var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");               
        
        var result = await client.PostAsync("your url", content);
        return await result.Content.ReadAsStringAsync();
    }
