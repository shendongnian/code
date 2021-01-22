    public void Save() {
      try
    	{
    	  Session.SaveOrUpdate(this);
    	}
    	catch
    	{
    	  // If the object as a null identifier everything else fails. Remove from context
    	  if (Session.GetIdentifier(this) == null)
    	    ((SessionImpl)Session).PersistenceContext.EntityEntries.Remove(this);
    	  throw;
    	}
      }
