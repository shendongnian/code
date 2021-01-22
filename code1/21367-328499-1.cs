    SqlConnection sqlConn = null;
    SqlCommand cmd = null;
    SqlDataReader sqlData= null;
    try
    {
        //new'ing here
        //connection opening, reading ...etc
    }
    catch(Exception ex)
    {
        throw ex;
    }
    finally
    {
        if(cmd != null)
            cmd.Dispose();
        if(conn != null)
        {
            conn.Close();
            conn.Dispose();
        }
        if(sqlData != null)
        {        
            sqlData.Close();
            sqlData.Dispose();
        }
    }
