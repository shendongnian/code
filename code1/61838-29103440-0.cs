    private const string SQL_CONNECTION = "Your Connection String Here";
    private void Test(string sqlCmd)
    {
      using (var cmd = new SqlCommand(sqlCmd, new SqlConnection(SQL_CONNECTION)))
      {
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        // Close() is not really necessary.
        // Dispose will Close the connection.
      }
    }
