    using (var Conn = new SqlConnection(_ConnectionString))
    {
        SqlTransaction trans = null;
        try
        {
            Conn.Open();
            trans = Conn.BeginTransaction();
    
            using (SqlCommand Com = new SqlCommand(ComText, Conn))
            {
                /* DB work */
            }
            trans.Commit();
        }
        catch (Exception Ex)
        {
            if (trans != null) trans.Rollback();
            return -1;
        }
    }
