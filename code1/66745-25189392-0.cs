      public static bool AccessToWebService()
      {
          string host = "http://192.168.99.41";
          try
          {
              HttpWebRequest request = (HttpWebRequest) WebRequest.Create(host);
              request.Method = "HEAD";
              HttpWebResponse response = (HttpWebResponse) request.GetResponse();
              return response.StatusCode == HttpStatusCode.OK;
          }
          catch (Exception)
          {
              return false;
          }
      }
