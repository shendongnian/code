    using (SqlDataReader reader = cmd.ExecuteReader())
    {
           if (reader != null)
           {
                  while (reader.Read())
                  {
                            //do something
                  }
                  reader.Close(); // <-- optional
           }
    }
