    public Customer LoadCustomerByName(
      SqlConnection conn,
      SqlTransaction trn,
      String name)
    {
      using (Sqlcommand cmd = new SqlCommand(@"SELECT ... FROM ...", conn, trn))
      {
        cmd.Parameters.AddWithValue("@name", name);
        using (SqlDataReader rdr = cmd.ExecuteReader ())
        {
          Customer c = new Customer();
          // Load c from rdr
          return c;
        }
      }
    }
