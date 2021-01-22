    public static class SessionFacade
    {
      public static string CurrentLanguage
      {
        get
        {
          //Simply returns, but you could check for a null
          //and initialise it with a default value accordingly...
          return HttpContext.Current.Session["current_language"].ToString();
        }
        set
        {
          HttpContext.Current.Session["current_language"] = value;
        }
      }
    }
