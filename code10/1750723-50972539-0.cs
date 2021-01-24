    var cookieContainer = new CookieContainer();
    using (var client = new HttpClient(new HttpClientHandler()
    {
        CookieContainer = cookieContainer,
        UseCookies = true,
        AllowAutoRedirect = false
    }))
    {
        var content = new MultipartFormDataContent
            {
                { new StringContent(number), "data1" },
                { new StringContent(pun), "data2" },
            };
        var result = await client.PostAsync(RequestUriString, content, cancel);
        result = await client.GetAsync(RequestUriString, cancel);
        var text = await result.Content.ReadAsStringAsync();
        // ...
     }
