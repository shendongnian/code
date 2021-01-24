    public void XYZFunction()
    {
      var response = client.GetAsync(uri).Result; //we are running the awaitable task to complete and share the result with us first. It is a blocking call
      MemoryStream stream = new MemoryStream();
      response.Content.CopyToAsync(stream).Result; //same goes here
      System.Console.WriteLine(stream.Length);
    } 
