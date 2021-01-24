    try
    {
        //Your code here
    }
    catch (DbEntityValidationException de_ex)
    {
        //Exception thrown from System.Data.Entity.DbContext.SaveChanges when validating entities fails.
    }
    catch (DbUnexpectedValidationException du_ex)
    {
        //Exception thrown from System.Data.Entity.DbContext.GetValidationErrors when an
        //exception is thrown from the validation code.
    }
    catch (Exception ex)
    {
        //All remaining exception here 
    }
