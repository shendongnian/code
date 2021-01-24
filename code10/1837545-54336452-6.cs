     using (var client = CreateMailClientForPOST($"{BaseUrl}/"))
            {
               //removed code, you can call above code as method like
               var response= await client.DoThingAsAsync($"{client.BaseAddress}, content").ConfigureAwait(false);
            }
    protected HttpClient CreateMailClientForPOST(string resource)
        {
            var handler = new HttpClientHandler();
            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate;
            }
           
            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri($"https://api.address.com/rest/{resource}")
            };
            return client;
        }
