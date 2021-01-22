    private void Test2(string sqlCmd)
    {
      using (var cmd = new SqlCommand(sqlCmd, OpenConnection))
      {
        cmd.ExecuteNonQuery();
      }
    }
