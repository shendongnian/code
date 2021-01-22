    void Page_Load(object sender, EventArgs e)
    {
      if(!IsPostBack)
      {
          RemoteCall();
      }
    }
    void RemoteCall()
    {
     var client = new SearchClient();
     try
     {
         var results = client.Search(params);
         clients.Close();
     }
     catch(CommunicationException cex)
     {
       //handle
     }
     catch(Exception ex)
     {
       //handle
     }
     finally
     {
         ((IDisposable)client).Dispose();
     }
    }
    
