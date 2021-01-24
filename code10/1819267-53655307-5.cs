    public void Submit(string token, string json)
    {
        using (var client = new HttpClient())
        {
            var message = client.PostAsync(
                "https://api-url-goes-here/access_token=" + token,
                new StringContent(json, Encoding.UTF8, "application/json")).GetAwaiter().GetResult();
            var content = message.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Console.Write(content);
        }
    }
