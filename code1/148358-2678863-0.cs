    public class AppContext : IAppConext
    {
      public string GetIP()
      {
        return HttpContext.Current.Request.UserHostName.ToString();
      }
    }
