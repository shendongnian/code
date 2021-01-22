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
                    //TESTING: throw new System.InvalidOperationException("Something bad happened.");
                }
                ts.Complete();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
