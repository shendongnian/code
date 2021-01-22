    using (SqlCommand cmd = CreateSprocCommand("..."))
    {
      using (var connection = cmd.Connection)
      {
         connection.Open();
         using (var reader = cmd.ExecuteReader())
         {
             ...
         }
         ...
      }
    }
