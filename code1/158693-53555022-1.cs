    using (SqlConnection conn = new SqlConnection(conn3))
    {
        try
        {
            conn.Open();
            using (SqlTransaction ts = conn.BeginTransaction())
            {
                using (SqlCommand command = new SqlCommand(query, conn, ts))
                {
                    command.ExecuteNonQuery();
                    //TESTING: throw new System.InvalidOperationException("Something bad happened.");
                }
                ts.Commit();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
