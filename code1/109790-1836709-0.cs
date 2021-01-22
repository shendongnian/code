    private void beginGet(string endpoint, OpenReadCompletedEventHandler callback)
    {
      WebRequest.RegisterPrefix("http://", System.Net.Browser.WebRequestCreator.ClientHttp);  
      WebClient wc = new WebClient();  
      wc.Credentials = new NetworkCredential(username, password);
      wc.UseDefaultCredentials = false; 
      wc.OpenReadCompleted += callback;  
      wc.OpenReadAsync(new Uri(baseURL + endpoint));
    }
