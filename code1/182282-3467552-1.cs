    public User GetUserByGuId(Int32 guid) 
    {
    	User user = null;
    	using (ITransaction tx = _session.BeginTransaction()) 
    	{
    		try 
    		{
    			user = _session.CreateQuery("from User u where u.UserGuid =:guid")
    			.SetParameter("guid", guid)
    			.UniqueResult<User>();
    			tx.Commit();
    		} 
    		catch (NHibernate.HibernateException) 
    		{
    			tx.Rollback();
    			throw;
    		}
    	}
    	return user;
    } 
