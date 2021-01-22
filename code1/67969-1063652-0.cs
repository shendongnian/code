    try  
    {
       Response.Redirect(...);
    }
    catch(ThreadAbortException)
    {
       throw;
    }
    catch(Exception e)
    {
      // Catch other exceptions
    }
