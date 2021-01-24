    public class Actions
    {
      public static string SendCommand(string action, string method)
      {
        var url = $"{Constants.BaseUrl}{action}";      
        var authheader = Security.AuthHeader(method, url, null);
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = method;
        request.Timeout = 1000;
        request.PreAuthenticate = true;
        request.Headers.Add("Authorization", authheader);
        request.Accept = "application/json";
        if(method.Equals("post", StringComparison.InvariantCultureIgnoreCase)) 
           request.ContentType = "application/json";
         var output = string.Empty;
        try
        {
          using (var response = request.GetResponse())
          {
            using (var reader = new StreamReader(response.GetResponseStream()))
              output = reader.ReadToEnd();
          }
        }
        catch (WebException e)
        {
          using (var reader = new StreamReader(e.Response.GetResponseStream()))
          {
            output = reader.ReadToEnd();
          }
        }          
        return output;
      }
    
      public static string ReadChannel()
      {
        var action = $"/channels/{Constants.ChannelId}";
        const string method = "GET";
        return SendCommand(action, method);
      }
    }
