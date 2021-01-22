    string query = @"UPDATE staging.TestTable
                        SET Column1 = 2";
                
    using (SqlConnection conn = new SqlConnection(conn2))
    {
        try
        {
            conn.Open();
            using (TransactionScope ts = new TransactionScope())
            {
                conn.EnlistTransaction(Transaction.Current);
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                    throw new System.InvalidOperationException("Something bad happened.");
                }
                ts.Complete();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
