    public static void ConfigureIoCFramework()
            {
                ObjectFactory.Initialize(x =>
                {
                       x.For<IDomainManager>().Use<DomainManager>();
                       x.For<IPersistantStorage>.Use<NHibernateStorage>();
                });
            }
