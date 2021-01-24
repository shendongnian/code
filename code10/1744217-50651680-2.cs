    try
    {
    	db.SaveChanges();
    }
    catch (DbUpdateException ex)
    {
    	if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2627)
    	{
    	}
    }
