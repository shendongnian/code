    using (SqlConnection Conn = new SqlConnection(_ConnectionString))
    {
    	SqlTransaction Trans = null;
        try
        {
            Conn.Open();
            Trans = Conn.BeginTransaction();
    
            using (SqlCommand Com = new SqlCommand(ComText, Conn))
            {
                /* DB work */
            }
        }
        catch (Exception Ex)
        {
    		if (Trans != null)
    			Trans.Rollback();
            return -1;
        }
    }
