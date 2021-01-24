    public void Insert()
    {
         using(var connection = new SqlConnection(dbConnection))
         using(var command = new SqlCommand(query, connection))
         {
              connection.Open();
              command.Parameters.AddWithValue("", "");
              command.Params.Add("", SqlDbType.Int, "");
              command.ExecuteNonQuery();
         }
    }
