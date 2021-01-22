    using(TransactionScope tran = new TransactionScope()) {
        using(SqlConnection conn = new SqlConnection(cs)) {
          // either multiple commands on one connection
          using(SqlCommand cmd = conn.CreateCommand()) {
            // etc
          }
          using(SqlCommand cmd = conn.CreateCommand()) {
            // etc
          }
        }
        using(SqlConnection conn = new SqlConnection(cs)) {
          // or a separate connection
          using(SqlCommand cmd = conn.CreateCommand()) {
            // etc
          }
        }
        tran.Complete();
    }
