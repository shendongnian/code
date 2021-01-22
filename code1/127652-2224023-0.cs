    using(TransactionScope scope = ...) {
      using (SqlConnection conn = ...) {
        conn.Open();
        SqlCommand.Execute(...);
        SqlCommand.Execute(...);
      }
      scope.Complete();
    }
