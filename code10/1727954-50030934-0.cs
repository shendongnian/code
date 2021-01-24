    using (SqlCommand cmdMessages = new SqlCommand("SELECT * FROM Email where Sender = @usernameLog", conn))
    {
         cmdMessages.Parameters.Add(new SqlParameter("@usernameLog", Sender));
         using (SqlDataReader reader = cmdMessages.ExecuteReader())
         {
             int count = reader.FieldCount;
             while (reader.Read())
             {
                 for(int i = 0 ; i < count ; i++) 
                 {
                      Console.WriteLine(reader.GetValue(i));
                 }
             }
         }
    }
