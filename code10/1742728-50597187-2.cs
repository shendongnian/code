    // note i havent tested this, add pepper and salt to taste
    public static async Task CheckUrlAsync(Proxy proxy)
    {
       try
       {
    
          var request = WebRequest.Create(proxy.Url);
    
          if (proxy.ProxyUrl != null)
             request.Proxy = new WebProxy(proxy.ProxyUrl);
           
          using (var response = await request.GetResponseAsync())
          {
             using (var responseStream = response.GetResponseStream())
             {
                using (var reader = new StreamReader(responseStream))
                {
                   var responseString = reader.ReadToEnd();
                   if (responseString.Contains("asdasd"))
                      proxy.ProxyStatus = ProxyStatus.Valid;
                   else
                      proxy.ProxyStatus = ProxyStatus.Invalid;
                }
             }
          }
    
       }
       catch (Exception e)
       {
          proxy.ProxyStatus = ProxyStatus.Error;
          proxy.Error = e.Message;
       }
    }
