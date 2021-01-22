    StringBuilder json = new StringBuilder();
    
    using(SqlConnection cnn = new SqlConnection(your_connection_string)) 
    {
        cnn.open();
    
        using(SqlCommand cmd = new SqlCommand("name_of_stored_procedure", cnn)) 
        {
            cmd.Paramters.AddWithValue("@Param", "value");
    
            using(SqlDataReader reader = cmd.ExecuteReader()) 
            {
                while(reader.Read()) 
                {
                    json.AppendFormat("{{\"name\": \"{0}\"}}", reader["name"]);
                }
            }
        }
    
        cnn.close();
    } 
