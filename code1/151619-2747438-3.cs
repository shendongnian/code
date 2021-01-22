     System.Net.WebClient wc = new System.Net.WebClient();
    
      System.IO.StreamReader webReader = new System.IO.StreamReader(
             wc.OpenRead("http://your_website.com"));
      string webPageData = webReader.ReadToEnd();
