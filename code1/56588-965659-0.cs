    public virtual void Update(T entity)
    {
    	var dbcontext = DB;
    	dbcontext.GetTable<T>().Attach(entity, true);
    	try
    	{
    		// commit to database
    		DB.SubmitChanges();
    	}
    	catch (ChangeConflictException e)
    	{
    		Console.WriteLine(e.Message);
    		foreach (ObjectChangeConflict occ in DB.ChangeConflicts)
    		{
    			occ.Resolve(REFRESH_MODE);
    		}
    	}
    }
