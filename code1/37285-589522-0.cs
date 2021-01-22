    string sql = "SELECT * FROM Customers; SELECT * FROM Orders;";
    using (SqlCommand cmd = new SqlCommand(sql, connection))
    using (SqlDataReader rd = cmd.ExecuteReader())
    {
    
      while (rd.Read())
      {
        // Read customers
      }
    
      if (rd.NextResult())  // Change result set to Orders
      {
        while(rd.Read())
        {
          // Read orders
        }
    
      }
    }
