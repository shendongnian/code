    using (SqlConnection conn = new SqlConnection(connStr))
    {
        conn.Open();
        using (TransactionScope ts = new TransactionScope())
        {
            conn.EnlistTransaction(Transaction.Current);
        }
    }
