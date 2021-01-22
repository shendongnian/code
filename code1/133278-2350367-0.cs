    using(SqlDataReader rdr = com.ExecuteReader())
    {
         if(rdr.HasRows)
         {
           while(rdr.Read())
           {
            sb.Append(rdr.GetString(0)); 
            ..... etc
           }
         }
    }
