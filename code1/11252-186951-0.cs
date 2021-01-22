    public override bool WebSiteIsAvailable(string Url)
    {
      string Message = string.Empty;
      HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Url);
                
      // Set the credentials to the current user account
      request.Credentials = System.Net.CredentialCache.DefaultCredentials;
      request.Method = "GET";
    
      try
      {
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
          // Do nothing; we're only testing to see if we can get the response
        }
      }
      catch (WebException ex)
      {
        Message += ((Message.Length > 0) ? "\n" : "") + ex.Message;
      }
    
      return (Message.Length == 0);
    }
