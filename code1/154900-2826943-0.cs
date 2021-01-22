    try
    {
      SqlTransaction trans = connection.BeginTransaction();
      ///blah blah blah
    }
    catch(Exception theExceptionICareAbout)
    {
      try
      {
        if(trans != null)
        {
          trans.Rollback();
        }
      }
      catch {}
      throw;  //re-throws the meaningful exception.
    }
