    class SessionUser
    {
      public static SessionUser Instance()
      {
        var ctx = HttpContext.Current;
        var su = ctx["SessionUser"] as SessionUser;
        if (su == null)
        {
          ctx["SessionUser"] = su = new SessionUser();
        }
        return su;
      }
    }
