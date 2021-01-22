    static NHibernateHelper()
    {
        if(System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly("DAL");
            sessionFactory = cfg.BuildSessionFactory(); // <-- line 62
        }
    }
