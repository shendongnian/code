    using System.Configuration // Add a reference for this... ;
    
    public static class Config
    {
      public static string DbConnection
      {
        get
        {
          return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
      }
    
      public static string SomeValue
      {
        get 
        {
          return ConfigurationManager.AppSettings["SomeValue"].ToString();
        }
      }
    }
