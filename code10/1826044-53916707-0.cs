    using (var conn = SQLConClass.GetSQLConnection())
    using (SqlCommand cmd = conn.CreateCommand())
    { 
         cmd.CommandText = spname;
         cmd.CommandType = CommandType.StoredProcedure;
         using (var reader = cmd.ExecuteReader())
         { 
              ....
         }
    }
