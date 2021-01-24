    public void ConfigureAuth(IAppBuilder app)
    {
          //Add this line at first inside the function.
          System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
           
          //Other code 
    }
