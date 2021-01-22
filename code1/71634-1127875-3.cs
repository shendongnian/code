    {
        SqlConnection cn = null;
        try
        {
           cn = new SqlConnection();
           {
               SqlTransaction tr = null;
               try
               {
                   tr = cn.BeginTransaction())
        
                   //some code
                   tr.Commit();
                }
                finally
                {
                    if(tr != null && tr is IDisposable)
                    {
                        tr.Dispose();
                    }
                }
            }
        }
        finally
        {
            if(cn != null && cn is IDisposable)
            {
                cn.Dispose();
            }
        }
    }
