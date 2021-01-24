    public object GetData() 
    {
      object response = "";
      string token = "EF232354";
      string baseUrl = ConfigurationManager.AppSettings["BaseURL"].ToString();
      string endPoint = ConfigurationManager.AppSettings["EndPoint"].ToString();
    
      var httpWebRequest = (HttpWebRequest) WebRequest.Create(baseUrl + endPoint);
    
      httpWebRequest.ContentType = "application/json";
      httpWebRequest.Method = HttpVerb.GET.ToString();
      httpWebRequest.Headers.Add("token", token);
    
      using (var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse())
      {
        using (Stream dataStream = httpResponse.GetResponseStream())
        {
          using (StreamReader reader = new StreamReader(dataStream))
          {
            using(JsonReader sdr = new JsonTextReader(reader)) 
            {
              JsonSerializer serializer = new JsonSerializer();
              response = serializer.Deserialize(sdr);
            }
            return response;
          }
        }
        httpResponse.Close(); // For good measure. *should* be covered by Dispose.
      }
    }
