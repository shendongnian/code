    try
    {
        // code that may cause exceptions.
    }
    catch( Exception ex )
    {
       LogExceptionSomewhere(ex);
       throw;
    }
    finally
    {
        // CLR always tries to execute finally blocks
    }
