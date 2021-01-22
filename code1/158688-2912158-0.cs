    using (SqlConnection Conn = new SqlConnection(_ConnectionString))
    {
        try
        {
            Conn.Open();
            SqlTransaction Trans = Conn.BeginTransaction();
    
            try 
            {
                using (SqlCommand Com = new SqlCommand(ComText, Conn))
                {
                    /* DB work */
                }
            }
            catch (Exception TransEx)
            {
                Trans.Rollback();
                return -1;
            }
        }
        catch (Exception Ex)
        {
            return -1;
        }
    }
