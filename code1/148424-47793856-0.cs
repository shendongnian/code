    SqlCeConnection conn = new SqlCeConnection(ConnectionString);
    conn.Open();
    using (SqlCeCommand cmd =
        new SqlCeCommand("SELECT stuff FROM SomeTable", conn))
    {
      // do some stuff
    }
