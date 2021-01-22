    public class ConnectionStringProvider
    {
      public static string GetConnectionString()
      {
        #if (DEBUG)
          return DevConnectionString;
        #else
          return ProdConnectionString;
        #endif
      }
    }
