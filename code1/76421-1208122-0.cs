    public void Main(..)
    {
      new Thread(new ThreadStart(SendData)).Start();
    }
    
    public void SendData()
    {
      while(true)
      {
        using (var client = new WebClient())
        {
          byte[] responseArray = client.UploadValues(Server, myNameValueCollection);
          Answer =   Encoding.ASCII.GetString(responseArray);
        }
    
        Thread.Sleep(120000);  // sleep for 2 mins between cycles    
      }
    }
