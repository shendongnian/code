    public static class UserHelper
    {
      public static void SetUser(User user)
      {
        HttpContext.Current.Session["user"]= user;
      }
      public static User GetCurrentUser()
      {
       return (User)HttpContext.Current.Session["user"];
      }
    }
