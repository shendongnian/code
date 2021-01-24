    try
    {
    }
    catch(DbEntityValidationException ex)
    {
       var firstErrorMessage = ex.EntityValidationErrors.First().ValidationErrors.First()
                       .ErrorMessage;
    }
