    public static class DCHelper
    {
      public static MyDataContext Create()
      {
         return new MyDataContext(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
      }
    }
