    string connectionString = "...";
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
      conn.Open();
      string sql = "select field from mytable";
      SqlCommand cmd = new SqlCommand(sql, conn);
      SqlDataReader rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        Console.WriteLine(rdr[0]);
      }
    }
