    public virtual void Update(T entity)
    {
    	var DB = ...;
    	DB.GetTable<T>().Attach(entity, true);
    	try
    	{
    		// commit to database
    		DB.SubmitChanges(ConflictMode.ContinueOnConflict);
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
