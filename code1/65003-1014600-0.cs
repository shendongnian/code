    using(SqlConnection conn = new SqlConnection("connection string"))
    {
        conn.Open();
    
        using(SqlTransaction trans = conn.BeginTrasnaction())
        {
            try
            {
                using(SqlCommand cmd = new SqlCommand("command text", conn, trans))
                {
                    // add parameters, then loop over your values and insert your rows
                }
    
                trans.Commit();
            }
            catch
            {
                trans.Rollback();
    
                throw; // so the exception can propogate up
            }
        }
    }
