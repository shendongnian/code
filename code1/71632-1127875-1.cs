    SqlConnection cn = null;
    try
    {
      cn = new SqlConnection();
    
      SqlTransaction tr = null;
      try
      {
        tr = cn.BeginTransaction())
        
        //some code
        tr.Commit();
      }
      finally
      {
        if(tr != null)
        {
           tr.Dispose();
        }
      }
    }
    finally
    {
      if(cn != null)
      {
        cn.Dispose();
      }
    }
