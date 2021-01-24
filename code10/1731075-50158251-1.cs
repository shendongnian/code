    public void Simple_factory_creation() {
        var container = new Container(cfg => {
            cfg.For<ICacheManagerConfiguration>().Use<CacheManagerFactory>();
            cfg.For<ICacheManagerConfigFactory>().CreateFactory();
        });
        var cache = container.GetInstance<ICacheManagerConfiguration>();
    }	
