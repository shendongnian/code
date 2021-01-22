    public void example2() {
      using (SqlConnection connection = new SqlConnection(this.connectionString))
      using (SqlCommand command = connection.CreateCommand())
      using (SqlTransaction transaction = command.BeginTransaction()) {
        // Execute some database statements.
        transaction.Commit();
      }
    }
