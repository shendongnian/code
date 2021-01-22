    public class NHibernateSessionManager : INHibernateSessionManager
    {	
    	private readonly ISessionFactory _sessionFactory;
    
    	public NHibernateSessionManager()
    	{		     
    		_sessionFactory = GetSessionFactory();
    	}
    }
