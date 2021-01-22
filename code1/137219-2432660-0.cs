    public static string ConnectionString
    {
        get
        {
          Type cp = typeof(NHibernate.Connection.DriverConnectionProvider);
          var cspi= cp.GetProperty("ConnectionString", 
                                   BindingFlags.Instance | BindingFlags.NonPublic);
          string cs = (string)cspi.GetValue(sessionFactory.ConnectionProvider, null);
          return cs;
        }
    }
