    HttpClient client = new HttpClient();
    client.DefaultRequestHeaders.Add("X-Auth-Token", "123");
    client.DefaultRequestHeaders.Add("Content-Type", "image/jpeg");
    using (var stream = File.OpenRead(@"c:\somepath\somefile.jpg"))
    {
        using (var content = new StreamContent(stream))
        {
            var result = client.PostAsync("https://www.someuri.com", content).Result;
        }  
    }
