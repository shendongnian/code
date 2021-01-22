    public string GetContent(string url)  
    { 
      using (System.Net.WebClient client =new System.Net.WebClient()) 
      { 
      return client.DownloadString(url); 
      } 
    } 
