    public static class ApplicationUtils
    {
       public static bool IsUserAManager(string username)
       {
          bool inAdmin;
    
          if (username == "AdminUser") {
             inAdmin = true;
          } else {
             inAdmin = false;
          }
    
          return inAdmin;
       }
    }
