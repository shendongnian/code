    Func<Task> doStuff = async delegate()
    {
      using (var client = new HttpClient())
      {
        var page = "http://en.wikipedia.org/";
        using (var response = await client.GetAsync(page))
        {
          using (var content = response.Content)
          {
            var result = await content.ReadAsStringAsync();
          }
        }
      }
    }
