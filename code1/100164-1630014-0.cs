    internal sealed class Utility
    {
         public static string MyConnectionString{
              get{
                   return ConfigurationManager.ConnectionString["MyConnection"].ConnectionString;
              }
         }
    }
