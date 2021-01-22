      Stream response = webRequest.GetResponse().GetResponseStream();
      StreamReader reader = new StreamReader(response);
      String line = null;
    
      while ( line = reader.ReadLine() ) 
      {
        if (line.Contains("hello"))
        {
          // increment your counter
        }
      }
