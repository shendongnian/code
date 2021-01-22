    public static Version GetHttpApplicationVersion() {
      Type lBase = typeof(HttpApplication);
      Type lType = BuildManager.GetGlobalAsaxType();
      if (lBase.IsAssignableFrom(lType))
      {
        while (lType.BaseType != lBase) { lType = lType.BaseType; }
        return lType.Assembly.GetName().Version;
      }
      else
      {
        return null;
      }
    }
