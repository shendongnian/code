    NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration();
    cfg.SetProperty("dialect", "NHibernate.Dialect.MySQLDialect");
    cfg.SetProperty("connection.driver_class", "NHibernate.Driver.MySqlDataDriver");
    cfg.SetProperty("connection.connection_string", "Server=YourServer;Database=YourDatabase;User ID=YourId;Password=YourPass;CharSet=utf8");
    cfg.SetProperty("proxyfactory.factory_class", "NHibernate.ByteCode.LinFu.ProxyFactoryFactory, NHibernate.ByteCode.LinFu");  
    cfg.AddAssembly("Your.Assembly.Name");  
    ISessionFactory sessionFactory = cfg.BuildSessionFactory();
