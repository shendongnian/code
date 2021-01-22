    //Somewhere in the main
    ConfigureWcf();
    ConnectToServer();
    //...
    
    void ConnectToServer()
    {
      myService = new ServiceReference.ServiceClient(context);
      myService.Open();
      myService.InnerChannel.UnknownMessageReceived += InnerChannel_UnknownMessageReceived;
      myService.InnerChannel.Closed += InnerChannel_Closed;
    }
    
    void StartConnecting()
    {
       //use 5 attempts to connect to server
       ConnectToServer();
    }
    
    void InnerChannel_Closing(object sender, EventArgs e)
    {
      //Connection to server closed!
      //Write to log
      StartConnecting(); 
    }
