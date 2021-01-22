            IDictionary<string, string> props = new Dictionary<string, string>();
            props["show_sql"] = "true";
            Configuration config = new NHibernate.Cfg.Configuration();
            config.SetProperties(props);
            config.Configure();
            config.AddAssembly(typeof(User).Assembly);
            ISessionFactory factory = config.BuildSessionFactory();
