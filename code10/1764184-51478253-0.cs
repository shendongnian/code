    using (var conn = new SqlConnection(connectionString))
    {
        using (var cmd = new SqlCommand("ProcedureName", conn) { 
                               CommandType = CommandType.StoredProcedure }) 
        {
           conn.Open();
           cmd.Parameters.Add(new SqlParameter("@f", variableOfF);
           cmd.Parameters.Add(new SqlParameter("@n", variableOfN);
           
           using (SqlDataReader reader = cmd.ExecuteReader())
           {
               while (reader.Read())
               {
                   int id = Convert.ToInt32(reader["id"]);
                   string name = reader["name"].ToString();
                   string family = reader["family"].ToString();
                   string description = reader["description"].ToString();
                   // do whatever you need to with the variables
               }
           }
        }
    }
