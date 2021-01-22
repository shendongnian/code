    public sealed class SessionProvider
    {
            static readonly SessionProvider provider = new SessionProvider();
            private static NHibernate.Cfg.Configuration config;
            private static ISessionFactory factory;
            static ISession session = null;
    
            /// <summary>
            /// Initializes the <see cref="SessionProvider"/> class.
            /// </summary>
            static SessionProvider() { }
    
            /// <summary>
            /// Gets the session.
            /// </summary>
            /// <value>The session.</value>
            public static ISession Session
            {
                get
                {
                    if (factory == null)
                    {
                        config = new NHibernate.Cfg.Configuration();
                        config.Configure();
    
                        factory = config.BuildSessionFactory();
                    }
    
                    if (session == null)
                    {                   
                        if (config.Interceptor != null)
                            session = factory.OpenSession(config.Interceptor);
                        else
                            session = factory.OpenSession();
                    }
    
                    return session;
                }
            }
        }
    public sealed class OrderDataControl
    {
            
            private static ILog log = LogManager.GetLogger(typeof(OrderDataControl));
    
            private static OrderDataControl orderDataControl;
            private static object lockOrderDataControl = new object();
            /// <summary>
            /// Gets the thread-safe instance
            /// </summary>
            /// <value>The instance.</value>
            public static OrderDataControl Instance
            {
                get
                {
                    lock (lockOrderDataControl)
                    {
                        if (orderDataControl == null)
                            orderDataControl = new OrderDataControl();
                    }
                    return orderDataControl;
                }           
            }
    
            /// <summary>
            /// Gets the session.
            /// </summary>
            /// <value>The session.</value>
            private ISession Session
            {
                get
                {
                    return SessionProvider.Session;                
                }
            }
    
    
            /// <summary>
            /// Saves the specified contact.
            /// </summary>
            /// <param name="contact">The contact.</param>
            /// <returns></returns>
            public int? Save(OrderItems contact)
            {
                int? retVal = null;
                ITransaction transaction = null;
    
                try
                {
                    transaction = Session.BeginTransaction();
                    Session.SaveOrUpdate(contact);
    
                    if (transaction != null && transaction.IsActive)
                        transaction.Commit();
                    else
                        Session.Flush();
    
                    retVal = contact.Id;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    if (transaction != null && transaction.IsActive)
                        transaction.Rollback();
                    throw;
                }
    
                return retVal;
            }
