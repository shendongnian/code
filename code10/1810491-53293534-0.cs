    using (SqlConnection sqlConn = new SqlConnection("myConnectionString"))
    {
      sqlConn.Open();
      ...
    }
