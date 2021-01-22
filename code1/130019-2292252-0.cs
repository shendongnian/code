    using(var tx = session.BeginTransaction())
    {
    	try
    	{
    		session.Save(entity);
    		session.Flush();
    		
    		//perform non NH operations with entity.id
    					
    		tx.Commit();
    	}
    	catch (Exception)
    	{
    		tx.Rollback();
    		throw;
    	}
    }
