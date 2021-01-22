     public class Common
        {
            public const string NHibernateSessionKey = "nhibernate.session.key";
    
            public static string ConnString
            {
                get
                {
                    return System.Configuration.ConfigurationManager.ConnectionStrings["JewelSoftMySqlConn"].ConnectionString;
                }
            }
    
            public static ISessionFactory  FACTORY = CreateFactory();
    
            static ISessionFactory CreateFactory()
            {
                Configuration config = new Configuration();
                IDictionary props = new Hashtable();
               
                props.Add("hibernate.dialect", "NHibernate.Dialect.MySQLDialect");
                props.Add("hibernate.connection.provider", "NHibernate.Connection.DriverConnectionProvider");
                props.Add("hibernate.connection.driver_class", "NHibernate.Driver.MySqlDataDriver");
                props.Add("hibernate.connection.connection_string", Common.ConnString);
                config.AddProperties(props);
    
                config.AddInputStream(new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(Resource.Models_hbm)));
    
                return config.BuildSessionFactory();
            }
    
            public static ISession GetCurrentSession()
            {
                ISession currentSession = null;
                HttpContext context = HttpContext.Current;
                if (context != null)
                {
                    currentSession = context.Items[NHibernateSessionKey] as ISession;
                    if (currentSession == null)
                    {
                        currentSession = FACTORY.OpenSession();
                        context.Items[NHibernateSessionKey] = currentSession;
                    }
                }
                else//will work non web request, like in test environment
                    currentSession = FACTORY.OpenSession();
    
                return currentSession;
            }
        }
