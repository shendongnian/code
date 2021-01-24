    try
    {
        //Your code here
    }
    catch (Exception ex)
    {
        if (ex.GetType() == typeof(DbEntityValidationException))
        {
            //Exception thrown from System.Data.Entity.DbContext.SaveChanges when validating entities fails.
        }
        else
        if (ex.GetType() == typeof(DbUnexpectedValidationException))
        {
            //Exception thrown from System.Data.Entity.DbContext.GetValidationErrors when an
            //exception is thrown from the validation code.
        }
        else
        {
            //All remaining exception here 
        }
    }
