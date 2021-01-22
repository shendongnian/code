    // SqlConnection and SqlCommand are IDisposable, so stack a couple using()'s
    using (SqlConnection conn = new SqlConnection(connectionString))
    using (SqlCommand cmd = new SqlCommand("sproc", conn)
    {
       // Create parameter with Direction as Output (and correct name and type)
       SqlParameter outputIdParam = new SqlParameter("@ID", SqlDbType.Int)
       { 
          Direction = ParameterDirection.Output 
       };
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.Add(outputIdParam);
           
       conn.Open();
       cmd.ExecuteNonQuery();
       // Some various ways to grab the output depending on how you would like to
       // handle a null value returned from the query (shown in comment for each).
       // Note: You can use either the SqlParameter variable declared
       // above or access it through the Parameters collection by name:
       //   outputIdParam.Value == cmd.Parameters["@ID"].Value
       // Throws FormatException
       int idFromString = int.Parse(outputIdParam.Value.ToString());
       // Throws InvalidCastException
       int idFromCast = (int)outputIdParam.Value; 
       // idAsNullableInt remains null
       int? idAsNullableInt = outputIdParam.Value as int?; 
       // idOrDefaultValue is 0 (or any other value specified to the ?? operator)
       int idOrDefaultValue = outputIdParam.Value as int? ?? default(int); 
    
       conn.Close();
    }
