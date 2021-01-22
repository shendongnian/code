    using(TransactionScope tran = new TransactionScope()) {
        using(SqlConnection conn = new SqlConnection(cs))
        using(SqlCommand cmd = conn.CreateCommand()) {
            // etc
        }
    }
