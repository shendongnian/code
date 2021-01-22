    public static class App
    {
      public static IAppRegistration IncludeAppFor(AppType type)
      {
        return new AppRegistration(type);
      }
    }
    public class AppRegistration
    {
      private AppType _type;
      private bool _cost;
      public AppRegistration(AppType type)
      {
        _type = type;
      }
      public AppRegistration AtNoCost()
      { 
        _cost = 0;
        return this;
      }
    }
