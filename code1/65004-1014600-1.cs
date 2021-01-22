    using(SqlConnection conn = new SqlConnection("connection string"))
    {
        conn.Open();
    
        using(SqlTransaction trans = conn.BeginTrasnaction())
        {
            try
            {
                using(SqlCommand cmd = new SqlCommand("command text", conn, trans))
                {
                    SqlParameter aParam = new SqlParameter("a", SqlDbType.Int);
                    SqlParameter bParam = new SqlParameter("b", SqlDbType.Int);
                    cmd.Parameters.Add(aParam);
                    cmd.Parameters.Add(bParam);
                    aParam.Value = 1;
                    foreach(int value in bValues)
                    {
                        bValue = value;
                        cmd.ExecuteNonQuery();
                    }
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
