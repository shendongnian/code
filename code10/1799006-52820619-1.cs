    HttpClient client = new HttpClient();
    client.DefaultRequestHeaders.Add("X-Auth-Token", "123");
    using (var stream = File.OpenRead(@"c:\somepath\somefile.jpg"))
    {
        using (var content = new StreamContent(stream))
        {
            content.Headers.Add("Content-Type", "image/jpeg");
            var result = client.PostAsync("https://www.someuri.com", content).Result;
        }  
    }
