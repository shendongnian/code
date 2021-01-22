    using(SqlConnection con = createConnection())
    {
        using(SqlCommand com = con.CreateCommand())
       {
           con.Open();
           com.CommandText = createQuery(expression);
           
           using(SqlDataReader reader = com.ExecuteReader())
           {
               while(reader.Read())
               {
                   yield return createClrObjectFromReader(reader);
               }
           }
       }
    }
