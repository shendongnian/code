    public string Example() 
    {
       try
       {
          /* Method Logic */
          return string.Empty;
       }
       catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("400"))
       {
          ProvideFault(e, "", e.Message);
       }
    }
    
    public void ProvideFault(System.Net.Http.HttpRequestException error, MessageVersion version, ref Message fault)
    {
       /* your logic according to your needs. */
    }
