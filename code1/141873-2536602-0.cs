    private static int SomeValue
    {
         get
         {
             int result = 60; //Some default value
             string str = ConfigurationManager.AppSettings["SomeValue"];
             if (!String.IsNullOrEmpty(str))
             {
                 Int32.TryParse(str, out result);
             }
             return result;
          }
    }
