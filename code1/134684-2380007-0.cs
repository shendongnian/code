    public static bool IsConnected 
    { 
      get 
      {
           return ConfigurationManager.AppSettings["Online"] == "true";
      }
    }
