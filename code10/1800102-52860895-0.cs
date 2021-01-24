    public async Task XYZFunction()
    {
      var response = await client.GetAsync(uri); //we are waiting for the request to be completed
      MemoryStream stream = new MemoryStream();
      await response.Content.CopyToAsync(stream); //The call will wait until the request is completed
      System.Console.WriteLine(stream.Length);
    } 
