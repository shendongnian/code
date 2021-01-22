    using (var client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true, CookieContainer = new CookieContainer() }))
    {
      response = client.PostAsync(documentAddApi, documentContent).Result;
      var responseContent = response.Content.ReadAsStringAsync().Result;
     }
