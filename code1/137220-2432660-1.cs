    public static string ConnectionString
    {
      get
      {
        NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration();
        return cfg.GetProperty(NHibernate.Cfg.Environment.ConnectionString);
      }
    }
