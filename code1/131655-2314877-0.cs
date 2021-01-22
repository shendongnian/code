    if (reader.HasResults())
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
