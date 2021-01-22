    public static class ApplicationConfiguration
    {
        private static DateTime myEpoch;
        public static DateTime Epoch
        {
           get
           {
              if (myEpoch == null)
              {
                  string startEpoch = ConfigurationManager.AppSettings["Epoch"];
                  if (string.IsNullOrEmpty(startEpoch))
                  {
                     myEpoch = new DateTime(1970,1,1);
                  }
                  else
                  {
                     myEpoch = DateTime.Parse(startEpoch);
                  }
              }
              return myEpoch;   
           }
        }
    }
