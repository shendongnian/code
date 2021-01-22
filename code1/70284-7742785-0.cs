    public class BackOfficeSessionFactoryCreator : ISessionFactoryCreator
    {
        public ISessionFactory CreateSessionFactory()
        {
            var sessionFactory =Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2005.ConnectionString(ConfigurationManager
            .AppSettings["FluentNHibernateConnectionForBackOffice"]))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Customer>())
            .ExposeConfiguration(c => c.SetProperty("command_timeout",ConfigurationManager
            .AppSettings["FluentNHibernateCommandTimeout"]));
            return sessionFactory.BuildSessionFactory();
        }
    }
    public class CheckoutSessionFactoryCreator : ISessionFactoryCreator
    {
        public ISessionFactory CreateSessionFactory()
        {
            var sessionFactory =Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2005.ConnectionString(ConfigurationManager
            .AppSettings["FluentNHibernateConnectionForCheckout"]))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerCheckOut>())
            .ExposeConfiguration(c => c.SetProperty("command_timeout",ConfigurationManager
            .AppSettings["FluentNHibernateCommandTimeout"]));
            return sessionFactory.BuildSessionFactory();
        }
    }
    public interface ISessionFactoryCreator
    {
        ISessionFactory CreateSessionFactory();
    }
