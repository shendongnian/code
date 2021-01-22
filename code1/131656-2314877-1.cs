    if (reader.HasRows)
    {
         do
         {
            while (reader.Read())
            {
                 ...
            }
         }
         while (reader.NextResult());
    }
