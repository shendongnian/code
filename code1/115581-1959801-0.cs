    using (var client = new HttpClient())
    {
       var page = client.Get("http://example.com").EnsureStatusIsSuccessful()
                        .Content.ReadAsString();
    }
