    try
    {
    	db.SaveChanges();
    }
    catch (DbUpdateException ex)
    {
    	if (ex.InnerException != null && ex.InnerException is SqlException 
            && ((SqlException)ex.InnerException).Number == 2627)
    	{
    	}
    }
