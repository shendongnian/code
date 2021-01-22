    SqlConnection conn = null;
    SqlTransaction trans = null;
    
    try
    {
       conn = new SqlConnection(_ConnectionString);
       conn.Open();
       trans = conn.BeginTransaction();
       /*
        * DB WORK
        */
       trans.Commit();
    }
    catch (Exception ex)
    {
       if (trans != null)
       {
          trans.Rollback();
       }
       return -1;
    }
    finally
    {
       if (conn != null)
       {
          conn.Close();
       }
    }
