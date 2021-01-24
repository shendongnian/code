    public string Example() 
    {
       try
       {
          /* Method Logic */
          return string.Empty;
       }
       catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("400"))
       {
          return "unauthorized";
       }
    }
